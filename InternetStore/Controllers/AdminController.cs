using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace InternetStore.Controllers
{
    public class AdminController : Controller
    {
        //private readonly IMongoDatabase _mongoDatabase;

        public AdminController()
        {

        }

        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}
