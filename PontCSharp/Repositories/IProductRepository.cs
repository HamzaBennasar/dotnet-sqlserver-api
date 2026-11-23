using PontCSharp.Models;


namespace PontCSharp.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> AddProductAsync(Product p);

        Task<bool> UpdateProductAsync(Product p);

        Task <bool> DeleteProductAsync(int id);

    }
}
