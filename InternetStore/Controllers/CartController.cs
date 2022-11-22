using InternetStore.Domain;
using InternetStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using InternetStore.Infrastructure;

namespace InternetStore.Controllers
{
    [Authorize(Policy = "User")]
    public class CartController : Controller
    {
        private readonly IMongoCollection<Cart> _carts;

        public CartController(IMongoDatabase _database)
        {
            _carts = _database.GetCollection<Cart>("Carts");
        }

        [Route("Cart")]
        [HttpGet]
        public IActionResult Cart()
        {
            
            ViewData["Cart"] = GetCart();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(ProductCart product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var cart = GetCart();

            var productToUpdateQuantity = cart.Products.Find(item => item.Id == product.Id && item.Size == product.Size);

            if (productToUpdateQuantity != null)
            {
                productToUpdateQuantity.Quantity++;
            }
            else
            {
                cart.Products.Add(product);
            }

            await _carts.ReplaceOneAsync(item => item.Id == cart.Id, cart, new ReplaceOptions { IsUpsert = true });

            HttpContext.Session.Set("Cart", cart);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> ClearCart()
        {
            var cart = GetCart(); 

            cart.Products.Clear();

            await _carts.ReplaceOneAsync(item => item.Id == cart.Id, cart, new ReplaceOptions { IsUpsert = true });

            HttpContext.Session.Set("Cart", cart);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart(string id)
        {
            var cart = GetCart();

            cart.Products.RemoveAll(item => item.Id == id);

            await _carts.ReplaceOneAsync(item => item.Id == cart.Id, cart, new ReplaceOptions { IsUpsert = true });

            HttpContext.Session.Set("Cart", cart);

            return Ok();
        }

        public Cart GetCart()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart");

            if (cart == null)
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                cart = _carts.Find(items => items.User.Email == email).FirstOrDefault();
                HttpContext.Session.Set("Cart", cart);
            }

            return cart;
        }
    }
}
