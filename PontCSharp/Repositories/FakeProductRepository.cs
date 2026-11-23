using PontCSharp.Models;


namespace PontCSharp.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private int _nextId;
        private readonly List<Product> _products = new()
        {
            new Product{Id=1,Name="Clavier",Price=15.00m},
            new Product{Id=2,Name="PC",     Price=200.00m},
            new Product{Id=3,Name="souris", Price=10.00m}
        };

        public FakeProductRepository()
        {
            _nextId = _products.Max(p => p.Id) +1;
        }

        Task<Product?> IProductRepository.GetProductByIdAsync(int id)
        {
            return Task.FromResult(_products.Find(p => p.Id == id));
        }

        Task<IEnumerable<Product>> IProductRepository.GetAllProductsAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_products);
        }

        Task<Product> IProductRepository.AddProductAsync(Product newProduct)
        {
                newProduct.Id = _nextId;
            
            _products.Add(newProduct);
            _nextId++;
            return Task.FromResult(newProduct);
        }

        Task<bool> IProductRepository.UpdateProductAsync(Product newProduct)
        {
            var productRecherchee = _products.Find(p => p.Id == newProduct.Id);

            if (productRecherchee == null)
            {
                return Task.FromResult(false);
            }
            else
            {
                productRecherchee.Name = newProduct.Name;
                productRecherchee.Price = newProduct.Price;
                return Task.FromResult(true);
            }
        }

        Task<bool> IProductRepository.DeleteProductAsync(int id)
        {
            var productRecherchee = _products.Find(p => p.Id == id);

            if(productRecherchee == null)
            {
                return Task.FromResult(false);
            }
            else
            {
                _products.Remove(productRecherchee);
                return Task.FromResult(true);
            }
        }

    }
}
