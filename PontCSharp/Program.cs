using PontCSharp.Models;
using PontCSharp.Repositories;
Console.OutputEncoding = System.Text.Encoding.UTF8;


IProductRepository productRepository;

try
{
    productRepository = ProductRepoFactory.CreateProductRepository(RepositoryType.AdoNet);
}
catch (ArgumentException ex)
{
    Console.Error.WriteLine($"Repository indisponible {ex.Message}");
    productRepository = ProductRepoFactory.CreateProductRepository(RepositoryType.Fake);  
}

foreach (var p in await productRepository.GetAllProductsAsync())
{
    Console.WriteLine(p);
}

var product = await productRepository.GetProductByIdAsync(2) ?? throw new InvalidOperationException("Product ID : 2");

Console.WriteLine(product.Name);

try
{
    var productRecherche = await productRepository.GetProductByIdAsync(999) ?? throw new InvalidOperationException("Product ID 999 introuvable");
    Console.WriteLine(productRecherche.Name);
}
catch (InvalidOperationException ex)
{
    Console.Error.WriteLine($"Product inexistant{ex.Message}");
}



Product prod = new() { Name = "Casque", Price = 70.00m };

Product prodRenvoie = await productRepository.AddProductAsync(prod);

Console.WriteLine(prodRenvoie);

foreach (var p in await productRepository.GetAllProductsAsync())
{
    Console.WriteLine(p);
}

Console.WriteLine("Dernier exercice de C3 : le scénario CRUD");

Product casqueAmelioree = new() { Id = 2, Name = "CasqueAmelioree", Price = 90.00m };


Console.WriteLine($"Update 2:{await productRepository.UpdateProductAsync(casqueAmelioree)}");

Console.WriteLine($"Display product 2:{await productRepository.GetProductByIdAsync(2)}");

Console.WriteLine($"Test update id 999: {await productRepository.UpdateProductAsync(new() { Id = 999, Name = "Rien", Price = 100.00m })}");

Console.WriteLine($"Delete id 3 : {await productRepository.DeleteProductAsync(3)}");

Console.WriteLine($"Test delete id 999: {await productRepository.DeleteProductAsync(999)}");

Console.WriteLine($"Ajout Cable: {await productRepository.AddProductAsync(new() { Name = "Cable", Price = 5.00m })}");

Console.WriteLine("Products list");

foreach (var p in await productRepository.GetAllProductsAsync())
{
    Console.WriteLine(p);
}



