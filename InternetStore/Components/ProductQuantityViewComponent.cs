using InternetStore.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MongoDB.Driver;
using System.Linq;
using Microsoft.AspNetCore.Http;
using InternetStore.Infrastructure;

namespace InternetStore.Components
{
    public class ProductQuantityViewComponent : ViewComponent
    {
        private readonly IMongoCollection<Cart> _carts;
        public ProductQuantityViewComponent(IMongoDatabase database)
        {
            _carts = database.GetCollection<Cart>("Carts");
        }   

        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart");

            if (cart == null)
            {
                var email = UserClaimsPrincipal.FindFirstValue(ClaimTypes.Email);
                cart = _carts.Find(items => items.User.Email == email).FirstOrDefault();
                HttpContext.Session.Set("Cart", cart);
            }

            var quantity = cart?.Products.Select(item => item.Quantity).Sum();

            return View(quantity);
        }
    }
}
