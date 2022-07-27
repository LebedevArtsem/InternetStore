using InternetStore.Models;
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
        var list = _products.Find(product => true).ToList();

        return View(list);
    }

    public IActionResult Product(Product product)
    {
        var prod = _products.Find(item => item.Id == product.Id).First();

        return View(prod);
    }

    public IActionResult Category(string categoryId)
    {
        var list = _products.Find(product => true).ToList();
        //var category = _categories.Find(new BsonDocument()).ToList();
        
        return View(list);
    }

    public IActionResult Cart()
    {
        return View();
    }

    public IActionResult Checkout()
    {
        return View();
    }
}