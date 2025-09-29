using IMS.CoreBusiness;

namespace IMS.Plugins.InMemory
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
        Task AddProductAsync(Product product);
        Task DeleteProductByIdAsync(int productId);
  
        Task<Product> GetProductByIdAsync(int productId);
        Task UpdateProductAsync(Product product);
    }
}