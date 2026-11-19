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

foreach (var p in productRepository.GetAllProducts())
{
    Console.WriteLine(p);
}

var product = productRepository.GetProductById(2) ?? throw new InvalidOperationException("Product ID : 2");

Console.WriteLine(product.Name);

try
{
    var productRecherche = productRepository.GetProductById(999) ?? throw new InvalidOperationException("Product ID 999 introuvable");
    Console.WriteLine(productRecherche.Name);
}
catch (InvalidOperationException ex)
{
    Console.Error.WriteLine($"Product inexistant{ex.Message}");
}



Product prod = new() { Name = "Casque", Price = 70.00m };

Product prodRenvoie = productRepository.AddProduct(prod);

Console.WriteLine(prodRenvoie);

foreach (var p in productRepository.GetAllProducts())
{
    Console.WriteLine(p);
}

Console.WriteLine("Dernier exercice de C3 : le scénario CRUD");

Product casqueAmelioree = new() { Id = 2, Name = "CasqueAmelioree", Price = 90.00m };


Console.WriteLine($"Update 2:{productRepository.UpdateProduct(casqueAmelioree)}");

Console.WriteLine($"Display product 2:{productRepository.GetProductById(2)}");

Console.WriteLine($"Test update id 999: {productRepository.UpdateProduct(new() { Id = 999, Name = "Rien", Price = 100.00m })}");

Console.WriteLine($"Delete id 3 : {productRepository.DeleteProduct(3)}");

Console.WriteLine($"Test delete id 999: {productRepository.DeleteProduct(999)}");

Console.WriteLine($"Ajout Cable: {productRepository.AddProduct(new() { Name = "Cable", Price = 5.00m })}");

Console.WriteLine("Products list");

foreach (var p in productRepository.GetAllProducts())
{
    Console.WriteLine(p);
}



