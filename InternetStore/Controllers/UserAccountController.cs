using InternetStore.Domain;
using InternetStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
    public async Task<IActionResult> SignIn(SignInUser user)
    {
        if (!ModelState.IsValid)
            return View(user);

        try
        {
            var findUser = _users.Find(signInUser => signInUser.Email == user.Email && signInUser.Password == user.Password).First();
        }
        catch (InvalidOperationException)
        {
            ViewData["Message"] = "Wrong login or password";
            return View(user);
        }

        var claims = new List<Claim> {
            new Claim(ClaimTypes.Email, $"{user.Email}"),
            new Claim("User","true")
        };

        var identity = new ClaimsIdentity(claims, "CookieAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

        return Redirect("~/Home/Index/");
    }

    [HttpGet]
    public IActionResult SignUp()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpUser user)
    {
        if (ModelState.IsValid)
        {
            var signUpUser = _users.Find(item => item.Email == user.Email).FirstOrDefault();

            if (signUpUser == null)
            {
                var newUser = new User(user.Email, user.Password);
                await _users.InsertOneAsync(newUser);

                return RedirectToAction("SignIn", "UserAccount");
            }
        }

        return View(user);
    }

    [HttpGet]
    public async Task<IActionResult> SignOutAsync()
    {
        await HttpContext.SignOutAsync("CookieAuth");

        return RedirectToAction("SignIn","UserAccount");
    }
}

