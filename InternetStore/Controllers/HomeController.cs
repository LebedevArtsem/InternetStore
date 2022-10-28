using InternetStore.Domain;
using InternetStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;
using System.Security.Claims;

namespace InternetStore.Controllers;
public class HomeController : Controller
{
    private readonly IMongoDatabase _mongoDatabase;

    private readonly IMongoCollection<Product> _products;

    private readonly IMongoCollection<Category> _categories;

    private readonly IMongoCollection<Cart> _carts;

    private readonly IMongoCollection<User> _users;

    public HomeController(IMongoDatabase mongoDatabase)
    {
        _mongoDatabase = mongoDatabase;
        _products = _mongoDatabase.GetCollection<Product>("Products");
        _categories = _mongoDatabase.GetCollection<Category>("Categories");
        _carts = _mongoDatabase.GetCollection<Cart>("Carts");
        _users = _mongoDatabase.GetCollection<User>("Users");

        ViewData["LayoutCategories"] = _categories.Find(item => true).ToList();
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Products"] = _products.Find(product => true).ToList();
        ViewData["Categories"] = _categories.Find(category => true).ToList();

        return View();
    }

    [HttpGet]
    public IActionResult Product(string id)
    {
        ViewData["Product"] = _products.Find(item => item.Id == id).First();

        return View();
    }

    [HttpGet]
    public IActionResult Category(string title, int page)
    {
        var products = _products.Find(product => product.Category.Title == title).ToList();
        ViewData["Category"] = _categories.Find(item => item.Title == title).First();
        ViewData["Pagination"] = Pagination<Product>.GetModel(page, 3, products);

        return View();
    }

    [HttpGet]
    [Authorize(Policy = "User")]
    public IActionResult Cart()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        ViewData["Cart"] = _carts.Find(cart => cart.User.Email == email).FirstOrDefault();
        var carts = _carts.Find(cart => cart.User.Email == email).FirstOrDefault();

        return View();
    }

    [HttpPost]
    [Authorize(Policy = "User")]
    public IActionResult AddToCart(ProductCart product)
    {
        if (!ModelState.IsValid)
            return View(product);

        var email = User.FindFirstValue(ClaimTypes.Email);
        var cart = _carts.Find(items => items.User.Email == email).FirstOrDefault();

        if (cart == null)
        {
            cart = new Cart();
            cart.User = _users.Find(user => user.Email == email).FirstOrDefault();
        }

        var productToUpdateQuantity = cart.Products.Find(item => item.Id == product.Id && item.Size == product.Size);

        if (productToUpdateQuantity != null)
        {
            productToUpdateQuantity.Quantity++;
        }
        else
        {
            cart.Products.Add(product);
        }

        _carts.ReplaceOne(item => item.Id == cart.Id, cart, new ReplaceOptions { IsUpsert = true });

        return Ok();
    }

    [HttpGet]
    [Authorize(Policy = "User")]
    public IActionResult Checkout()
    {
        return View();
    }
}