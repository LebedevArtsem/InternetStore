using InternetStore.Domain;

namespace InternetStore.Models
{
    public class ProductCart
    {
        public string Image { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Size { get; set; }

        public int Quantity { get; set; }
    }
}
