using PontCSharp.Models;
using PontCSharp.Repositories;

namespace PontCSharp.Tests
{
    public class FakeProductRepositoryTest
    {
        [Fact]
        public async Task GetAllProduct_DefaultData_ReturnThreeProducts()
        {
            IProductRepository repository = new FakeProductRepository();

            var numberOfProducts = await repository.GetAllProductsAsync();

            Assert.Equal(3, numberOfProducts.Count());

        }

        [Fact]
        public async Task GetProductById_ExistingId_ReturnProduct()
        {
            IProductRepository repository = new FakeProductRepository();

            var nameOfProduct = await repository.GetProductByIdAsync(2);

            Assert.NotNull(nameOfProduct);

            Assert.Equal("PC", nameOfProduct.Name);

        }

        [Fact]
        public async Task GetProductById_UnknownId_ReturnNull()
        {
            IProductRepository repository = new FakeProductRepository();

            var productIdNull = await repository.GetProductByIdAsync(999);

            Assert.Null(productIdNull);

        }

        [Fact]
        public async Task AddProduct_NewProduct_GetsNextId()
        {
            IProductRepository repository = new FakeProductRepository();

            Product prodTest = new() { Name = "Test", Price = 0.00m };

            var newProduct = await repository.AddProductAsync(prodTest);

            Assert.Equal(4, newProduct.Id);

        }

        [Fact]
        public async Task UpdateProduct_UpdateExistingProduct_returnTrue()
        {
            IProductRepository repository = new FakeProductRepository();

            Product productUpdate = new() { Id = 1, Name = "Clavier gaming", Price = 30.00m };

            var productUpdateisTrue = await repository.UpdateProductAsync(productUpdate);

            var productToUpdate = await repository.GetProductByIdAsync(1);

            Assert.True(productUpdateisTrue);

            Assert.NotNull(productToUpdate);

            Assert.Equal(productUpdate.Name, productToUpdate.Name);
        }

        [Fact]
        public async Task UpdateProduct_UpdateUnknownProduct_returnFalse()
        {
            IProductRepository repository = new FakeProductRepository();

            Product productUpdate = new() { Id = 999, Name = "Clavier gaming", Price = 30.00m };

            var checkUnknown = await repository.UpdateProductAsync(productUpdate);

            Assert.False(checkUnknown);
        }

        [Fact]
        public async Task DeleteProduct_DeleteExistingProduct_returnTrue()
        {
            IProductRepository repository = new FakeProductRepository();

            var productToDelete = await repository.DeleteProductAsync(3);

            var productNotNull = await repository.GetProductByIdAsync(3);

            Assert.True(productToDelete);

            Assert.Null(productNotNull);
        }

        [Fact]
        public async Task DeleteProduct_DeleteUnknownProduct_returnFalse()
        {
            IProductRepository repository = new FakeProductRepository();

            var checkUnknown = await repository.DeleteProductAsync(999);

            Assert.False(checkUnknown);

        }

        [Fact]
        public async Task AddProduct_AfterDeletingLastProduct_DoesNotReuseId()
        {
            IProductRepository repository = new FakeProductRepository();

            Product prodTest = new() { Name = "Phone case", Price = 5.00m };

            await repository.DeleteProductAsync(3);

            var resultatAddProduct = await repository.AddProductAsync(prodTest);

            Assert.NotEqual(3, resultatAddProduct.Id);


        }


    }
}
