using InternetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InternetStore.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IMongoDatabase _mongoDatabase;

    private readonly IMongoCollection<Product> _products;

    public HomeController(ILogger<HomeController> logger, IMongoDatabase mongoDatabase)
    {
        _logger = logger;
        _mongoDatabase = mongoDatabase;
        _products = _mongoDatabase.GetCollection<Product>("Products");
    }

    public IActionResult Index()
    {
        var list = _products.Find(Product => true).ToList();


        return View(list);
    }

    public IActionResult Product(string id)
    {
        var product = _products.Find(product => product.Id == id);

        return View(product);
    }

    public IActionResult Category()
    {
        var collection = _mongoDatabase.GetCollection<Product>("Products");
        var list = collection.Find(new BsonDocument()).ToList();
        return View(list);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}