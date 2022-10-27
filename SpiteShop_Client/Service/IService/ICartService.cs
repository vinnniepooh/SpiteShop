using SpiteShop_Client.ViewModels;
using SpiteShop_Models;

namespace SpiteShop_Client.Service.IService
{
    public interface ICartService
    {
        public event Action OnChange;
        public Task DecrementCart(ShoppingCart shoppingCart);
        public Task IncrementCart(ShoppingCart shoppingCart);
    }
}
