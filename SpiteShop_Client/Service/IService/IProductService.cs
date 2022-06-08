using SpiteShop_Models;

namespace SpiteShop_Client.Service.IService
{
    public interface IProductService
    {
        public  Task<ProductDTO> Get(int productId);

        public  Task<IEnumerable<ProductDTO>> GetAll();
    }
}
