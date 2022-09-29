using InternetStore.Domain;
using InternetStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Security.Claims;

namespace InternetStore.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IMongoDatabase _mongoDatabase;

    private readonly IMongoCollection<Product> _products;

    private readonly IMongoCollection<Category> _categories;

    private readonly IMongoCollection<Cart> _carts;

    private readonly IMongoCollection<User> _users;

    public HomeController(ILogger<HomeController> logger, IMongoDatabase mongoDatabase)
    {
        _logger = logger;
        _mongoDatabase = mongoDatabase;
        _products = _mongoDatabase.GetCollection<Product>("Products");
        _categories = _mongoDatabase.GetCollection<Category>("Categories");
        _carts = _mongoDatabase.GetCollection<Cart>("Carts");
        _users = _mongoDatabase.GetCollection<User>("Users");
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
    public IActionResult Category(Category category)
    {
        ViewData["Products"] = _products.Find(product => product.Category.Id == category.Id).ToList();
        ViewData["Category"] = _categories.Find(item => item.Id == category.Id).First();
        var categories = _products.Find(product => product.Category.Id == category.Id).ToList();

        return View();
    }

    [HttpGet]
    [Authorize(Policy = "User")]
    public IActionResult Cart()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var cart = _carts.Find(items => items.User.Email == email);
        //ViewData["Cart"]
        return View();
    }

    [HttpPost]
    [Authorize(Policy = "User")]
    public IActionResult AddToCart(ProductCart product)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var cart = _carts.Find(items => items.User.Email == email).FirstOrDefault();

        if (cart == null)
        {
            cart = new Cart();
            cart.User = _users.Find(user => user.Email == email).FirstOrDefault();  
        }

        cart.Products.Add(product);
        _carts.InsertOne(cart);

        return Ok();
    }

    [HttpGet]
    [Authorize(Policy = "User")]
    public IActionResult Checkout()
    {
        return View();
    }
}