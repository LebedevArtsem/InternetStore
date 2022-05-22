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

namespace InternetStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMongoDatabase _mongoDatabase;

        public HomeController(ILogger<HomeController> logger, IMongoDatabase mongoDatabase)
        {
            _logger = logger;
            this._mongoDatabase = mongoDatabase;
        }

        public IActionResult Index()
        {
            var collection = _mongoDatabase.GetCollection<Product>("Products");
            var list = collection.Find(new BsonDocument()).ToList();

            {
                //var product = new Product[] {
                //    new Product() {
                //        Image = "/Images/product_1.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 10,
                //        Rate = 4,
                //        Title = "Jacket",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "M",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //    new Product() {
                //        Image = "/Images/product_2.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 8,
                //        Rate = 3,
                //        Title = "Coat",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "M",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //    new Product() {
                //        Image = "/Images/product_3.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 11,
                //        Rate = 3,
                //        Title = "Suit",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "XS",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //    new Product() {
                //        Image = "/Images/product_4.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 5,
                //        Rate = 2,
                //        Title = "Blouse",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "M",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //    new Product() {
                //        Image = "/Images/product_5.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 7,
                //        Rate = 4,
                //        Title = "Jacket",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "L",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //    new Product() {
                //        Image = "/Images/product_6.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 10,
                //        Rate = 4,
                //        Title = "Suit",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "M",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //    new Product() {
                //        Image = "/Images/product_7.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 10,
                //        Rate = 5,
                //        Title = "Suit",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "S",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //    new Product() {
                //        Image = "/Images/product_8.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 6,
                //        Rate = 3,
                //        Title = "Jacket",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "M",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //    new Product() {
                //        Image = "/Images/product_9.jpg",
                //        Category = new Category() { Title = "Женское" },
                //        Price = 10,
                //        Rate = 4,
                //        Title = "Suit",
                //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                //        Size = "S",
                //        Id = Guid.NewGuid().ToString()
                //    },
                //};

                //collection.InsertMany(product);
            }

            return View(list);
        }

        public IActionResult Registration()
        {
            return View();
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
}
