using InternetStore.Domain;
using InternetStore.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace InternetStore.Controllers;
public class HomeController : Controller
{
    private readonly IMongoDatabase _mongoDatabase;

    private readonly IMongoCollection<Product> _products;

    private readonly IMongoCollection<Category> _categories;

    private readonly IMongoCollection<User> _users;

    public HomeController(IMongoDatabase mongoDatabase)
    {
        _mongoDatabase = mongoDatabase;
        _products = _mongoDatabase.GetCollection<Product>("Products");
        _categories = _mongoDatabase.GetCollection<Category>("Categories");
        _users = _mongoDatabase.GetCollection<User>("Users");

        ViewData["LayoutCategories"] = _categories.Find(item => true).ToList();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewData["Products"] = await _products.Find(product => true).ToListAsync();

        return View();
    }

    [Route("Catalog/{id}")]
    [HttpGet]
    public async Task<IActionResult> Product(string id)
    {
        ViewData["Product"] = await _products.Find(item => item.Id == id).FirstAsync();

        return View();
    }

    [Route("Catalog/{title}/Page_{page}")]
    [HttpGet]
    public IActionResult Category(string title, int page=1)
    {
        var products = _products.Find(product => product.Category.Title == title).ToList();
        ViewData["Category"] = _categories.Find(item => item.Title == title).First();
        ViewData["Pagination"] = Pagination<Product>.GetModel(page, 6, products);

        return View();
    }

    [HttpGet]
    [Authorize(Policy = "User")]
    public IActionResult Checkout()
    {
        return View();
    }
}