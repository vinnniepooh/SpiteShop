using SpiteShop_Models;

namespace SpiteShop_Client.Service.IService
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductDTO> Get(int id);
    }
}
