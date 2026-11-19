

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

        Product? IProductRepository.GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IProductRepository.GetAllProducts()
        {
            throw new NotImplementedException();
        }

        Product IProductRepository.AddProduct(Product p)
        {
            throw new NotImplementedException();
        }

        bool IProductRepository.UpdateProduct(Product p)
        {
            throw new NotImplementedException();
        }

        bool IProductRepository.DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

    }
}
