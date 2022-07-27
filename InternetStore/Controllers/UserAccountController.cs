using InternetStore.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace InternetStore.Controllers;
public class UserAccountController : Controller
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<User> _users;

    public UserAccountController(IMongoDatabase database)
    {
        _database = database;
        _users = _database.GetCollection<User>("Users");
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignIn(SignInUser user)
    {
        if (ModelState.IsValid)
        {
            await _users.FindAsync(signInUser => signInUser.Email == user.Email);
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUp(SignUpUser user)
    {
        if (ModelState.IsValid)
        {
            var signUpUser = _users.Find(item => item.Email == user.Email).FirstOrDefault();

            if (signUpUser == null)
            {
                var newUser = new User(user.Email, user.Password);
                await _users.InsertOneAsync(newUser);

                //await Authenticate(newUser.Email);

                return RedirectToAction("SignIn", "UserAccount");
            }
        }

        return View(user);
    }

    //private async Task Authenticate(string email)
    //{

    //}

    public new IActionResult SignOut()
    {

        return RedirectToAction("SignIn");
    }
}

