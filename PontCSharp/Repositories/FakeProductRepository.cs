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

        Product? IProductRepository.GetProductById(int id)
        {
            return _products.Find(p => p.Id == id);
        }

        IEnumerable<Product> IProductRepository.GetAllProducts()
        {
            return _products;
        }

        Product IProductRepository.AddProduct(Product newProduct)
        {
                newProduct.Id = _nextId;
            
            _products.Add(newProduct);
            _nextId++;
            return newProduct;
        }

        bool IProductRepository.UpdateProduct(Product newProduct)
        {
            var productRecherchee = _products.Find(p => p.Id == newProduct.Id);

            if (productRecherchee == null)
            {
                return false;
            }
            else
            {
                productRecherchee.Name = newProduct.Name;
                productRecherchee.Price = newProduct.Price;
                return true;
            }
        }

        bool IProductRepository.DeleteProduct(int id)
        {
            var productRecherchee = _products.Find(p => p.Id == id);

            if(productRecherchee == null)
            {
                return false;
            }
            else
            {
                _products.Remove(productRecherchee);
                return true;
            }
        }

    }
}
