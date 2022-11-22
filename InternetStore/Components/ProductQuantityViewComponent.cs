using InternetStore.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace InternetStore.Components
{
    public class ProductQuantityViewComponent:ViewComponent
    {
        private readonly IMongoCollection<Cart> _carts;
        public ProductQuantityViewComponent()
        {
            _carts = mongoDatabase.GetCollection<Cart>("Carts");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var email = UserClaimsPrincipal.FindFirstValue(ClaimTypes.Email);
            var cart = await _carts.Find(item => item.User.Email == email).FirstAsync();
            var quantity = cart?.Products.Select(item => item.Quantity).Sum();
            return View(quantity);
        }
    }
}
