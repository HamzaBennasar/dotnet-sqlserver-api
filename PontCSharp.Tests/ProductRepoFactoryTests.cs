using PontCSharp.Models;
using PontCSharp.Repositories;

namespace PontCSharp.Tests
{
    public class ProductRepoFactoryTests
    {

        [Fact]
        public void CreateProductRepository_FakeType_ReturnsFakeRepo()
        {
            IProductRepository productRepository = ProductRepoFactory.CreateProductRepository(RepositoryType.Fake);
            Assert.IsType<FakeProductRepository>(productRepository);
        }

        [Fact]
        public void CreateProductRepository_AdoNetWithoutConnectionString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ProductRepoFactory.CreateProductRepository(RepositoryType.AdoNet));
        }

        [Fact]
        public void CreateProductRepository_AdoNetWithConnectionString_ReturnAdoNetRepo()
        {
            IProductRepository productRepository = ProductRepoFactory.CreateProductRepository(RepositoryType.AdoNet,"Serve=test");
            Assert.IsType<AdoNetProductRepository>(productRepository);
        }

        [Fact]
        public void CreateProductRepository_UnknownType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ProductRepoFactory.CreateProductRepository((RepositoryType)99));
        }



    }
}
