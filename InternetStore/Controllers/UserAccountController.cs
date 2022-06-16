using InternetStore.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace InternetStore.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<User> _users;
        private User currentUser;

        public UserAccountController(IMongoDatabase database)
        {
            _database = database;
            _users = _database.GetCollection<User>("Users");
            currentUser = null;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInUser user)
        {
            if (ModelState.IsValid)
            {
                _users.Find(signInUser => signInUser.Email == user.Email).FirstOrDefault();
                return Redirect("~/Home/Index/");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpUser user)
        {
            if (!ModelState.IsValid)
                return View(user);

            var tempUser = _users.Find(signUpUser => signUpUser.Email == user.Email).FirstOrDefault();

            if (tempUser == null)
            {
                tempUser = new User(user.Email, user.Password);
                _users.InsertOne(tempUser);
                return Redirect("SignIn");
            }

            return View();
        }

        public new IActionResult SignOut()
        {

            return RedirectToAction("SignIn");
        }
    }
}
