using InternetStore.Domain;
using InternetStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetStore.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IMongoDatabase _mongoDatabase;

    private readonly IMongoCollection<Product> _products;

    private readonly IMongoCollection<Category> _categories;

    public HomeController(ILogger<HomeController> logger, IMongoDatabase mongoDatabase)
    {
        _logger = logger;
        _mongoDatabase = mongoDatabase;
        _products = _mongoDatabase.GetCollection<Product>("Products");
        _categories = _mongoDatabase.GetCollection<Category>("Categories");
    }


    public IActionResult Index()
    {
        ViewData["Products"] = _products.Find(product => true).ToList();
        ViewData["Categories"] = _categories.Find(category => true).ToList();

        return View();
    }

    [HttpGet]
    public IActionResult Product(Product product)
    {
        ViewData["Product"] = _products.Find(item => item.Id == product.Id).First();

        return View();
    }

    public IActionResult Category(Category category)
    {
        ViewData["Products"] = _products.Find(product => product.Category.Id == category.Id).ToList();
        //var category = _categories.Find(new BsonDocument()).ToList();
        ViewData["Category"] = _categories.Find(item => item.Id == category.Id).First();
        var categories = _products.Find(product => product.Category.Id == category.Id).ToList();

        return View();
    }

    [Authorize(Policy = "User")]
    public IActionResult Cart()
    {
        return View();
    }

    [Authorize(Policy = "User")]
    public IActionResult Checkout()
    {
        return View();
    }
}