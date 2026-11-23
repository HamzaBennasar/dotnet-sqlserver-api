

using PontCSharp.Models;

namespace PontCSharp.Repositories
{
    public class AdoNetProductRepository :IProductRepository
    {
        private readonly string _connectionString;


        public AdoNetProductRepository(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Argument invalide", nameof(connectionString));
            }
            _connectionString = connectionString;
        }

        Task<Product?> IProductRepository.GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        Task<Product> IProductRepository.AddProductAsync(Product p)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProductRepository.UpdateProductAsync(Product p)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProductRepository.DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
