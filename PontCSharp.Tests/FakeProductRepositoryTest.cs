using PontCSharp.Models;
using PontCSharp.Repositories;

namespace PontCSharp.Tests
{
    public class FakeProductRepositoryTest
    {
        [Fact]
        public void GetAllProduct_DefaultData_ReturnThreeProducts()
        {
            IProductRepository repository = new FakeProductRepository();

            var numberOfProducts = repository.GetAllProducts();

            Assert.Equal(3, numberOfProducts.Count());

        }

        [Fact]
        public void GetProductById_ExistingId_ReturnProduct()
        {
            IProductRepository repository = new FakeProductRepository();

            var nameOfProduct = repository.GetProductById(2);

            Assert.NotNull(nameOfProduct);

            Assert.Equal("PC", nameOfProduct.Name);

        }

        [Fact]
        public void GetProductById_UnknownId_ReturnNull()
        {
            IProductRepository repository = new FakeProductRepository();

            var productIdNull = repository.GetProductById(999);

            Assert.Null(productIdNull);

        }

        [Fact]
        public void AddProduct_NewProduct_GetsNextId()
        {
            IProductRepository repository = new FakeProductRepository();

            Product prodTest = new() { Name = "Test", Price = 0.00m };

            var newProduct = repository.AddProduct(prodTest);

            Assert.Equal(4, newProduct.Id);

        }

        [Fact]
        public void UpdateProduct_UpdateExistingProduct_returnTrue()
        {
            IProductRepository repository = new FakeProductRepository();

            Product productUpdate = new() { Id = 1, Name = "Clavier gaming", Price = 30.00m };

            var productUpdateisTrue = repository.UpdateProduct(productUpdate);

            var productToUpdate = repository.GetProductById(1);

            Assert.True(productUpdateisTrue);

            Assert.NotNull(productToUpdate);

            Assert.Equal(productUpdate.Name, productToUpdate.Name);
        }

        [Fact]
        public void UpdateProduct_UpdateUnknownProduct_returnFalse()
        {
            IProductRepository repository = new FakeProductRepository();

            Product productUpdate = new() { Id = 999, Name = "Clavier gaming", Price = 30.00m };

            var checkUnknown = repository.UpdateProduct(productUpdate);

            Assert.False(checkUnknown);
        }

        [Fact]
        public void DeleteProduct_DeleteExistingProduct_returnTrue()
        {
            IProductRepository repository = new FakeProductRepository();

            var productToDelete = repository.DeleteProduct(3);

            var productNotNull = repository.GetProductById(3);

            Assert.True(productToDelete);

            Assert.Null(productNotNull);
        }

        [Fact]
        public void DeleteProduct_DeleteUnknownProduct_returnFalse()
        {
            IProductRepository repository = new FakeProductRepository();

            var checkUnknown = repository.DeleteProduct(999);

            Assert.False(checkUnknown);

        }

        [Fact]
        public void AddProduct_AfterDeletingLastProduct_DoesNotReuseId()
        {
            IProductRepository repository = new FakeProductRepository();

            Product prodTest = new() { Name = "Phone case", Price = 5.00m };

            repository.DeleteProduct(3);

            var resultatAddProduct = repository.AddProduct(prodTest);

            Assert.NotEqual(3, resultatAddProduct.Id);


        }


    }
}
