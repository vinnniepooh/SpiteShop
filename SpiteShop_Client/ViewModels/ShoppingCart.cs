using SpiteShop_Models;
using System.ComponentModel.DataAnnotations;

namespace SpiteShop_Client.ViewModels
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }

        public ProductDTO Product { get; set; }
        public int ProductPriceId { get; set; }
        public ProductPriceDTO ProductPrice { get; set; }
        public int Count { get; set; }

    }
}
