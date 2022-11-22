using InternetStore.Domain;

namespace InternetStore.Infrastructure
{
    public interface ICartService
    {
        public void AddToCart(Product product);

        public void RemoveFromCart(string id);

        public void ClearCart();

        public Cart GetCart();
    }
}
