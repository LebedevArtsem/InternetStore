using InternetStore.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace InternetStore.Views.Shared
{
    public class _LayoutModel : PageModel
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<Category> _categories;
        public _LayoutModel(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _categories = _mongoDatabase.GetCollection<Category>("Categories");
        }

        public void OnGet()
        {

        }
    }
}
