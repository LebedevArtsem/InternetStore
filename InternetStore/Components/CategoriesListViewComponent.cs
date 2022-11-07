using InternetStore.Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetStore.Components
{
    public class CategoriesListViewComponent : ViewComponent
    {
        private readonly IMongoCollection<Category> _categories;
        public CategoriesListViewComponent(IMongoDatabase database)
        {
            _categories = database.GetCollection<Category>("Categories");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _categories.Find(item => true).ToListAsync();
            return View(items);
        }
    }
}
