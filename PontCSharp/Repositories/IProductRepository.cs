using PontCSharp.Models;


namespace PontCSharp.Repositories
{
    public interface IProductRepository
    {
        Product? GetProductById(int id);

        IEnumerable<Product> GetAllProducts();

        Product AddProduct(Product p);

        bool UpdateProduct(Product p);

        bool DeleteProduct(int id);

    }
}
