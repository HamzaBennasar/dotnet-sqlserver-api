using PontCSharp.Models;
using PontCSharp.Repositories;

namespace PontCSharp.Repositories
{
    public class ProductRepoFactory
    {
        public static IProductRepository CreateProductRepository(RepositoryType repositoryType, string? connectionString=null)
        {
            IProductRepository chosenRepository = repositoryType switch
            {
                RepositoryType.Fake => new FakeProductRepository(),
                RepositoryType.AdoNet => new AdoNetProductRepository(connectionString),
                _ => throw new ArgumentException("Argument invalide",nameof(repositoryType))
            };
            return chosenRepository;
        }
    }
}
