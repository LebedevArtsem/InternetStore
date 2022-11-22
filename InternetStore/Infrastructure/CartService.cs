using InternetStore.Domain;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System.Security.Claims;
using InternetStore.Models;

namespace InternetStore.Infrastructure
{
    public class CartService : ICartService
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<Cart> _carts;
        public CartService(IMongoDatabase datadase)
        {
            _database = datadase;
            _carts = datadase.GetCollection<Cart>("Carts");
        }

        public void AddToCart(Product product)
        {
            
        }

        public void ClearCart()
        {
            throw new System.NotImplementedException();
        }

        public Cart GetCart()
        {
            //var cart = HttpContext.Session.Get<Cart>("Cart");

            //if (cart == null)
            //{
            //    var email = User.FindFirstValue(ClaimTypes.Email);
            //    cart = _carts.Find(items => items.User.Email == email).FirstOrDefault();
            //    HttpContext.Session.Set("Cart", cart);
            //}

            return null;
        }

        public void RemoveFromCart(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
