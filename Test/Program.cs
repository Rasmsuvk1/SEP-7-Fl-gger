// See https://aka.ms/new-console-template for more information

using Domain.Models;
using EfcDataAccess;
using EfcDataAccess.DAOs;


static async Task Main()
{
    Console.WriteLine("Creating a new product...");

    // Set up DbContext and ProductDao
    await using var dbContext = new DbContext();
    var productDao = new ProductDao(dbContext);
    // Get product details from the user or hardcode them
        
    var product = new Product("NavyBlue","Room", 10,299,new DateOnly(2023,12,27), "");

    // Call the CreateAsync method to add the product to the database
    var createdProduct = await productDao.CreateAsync(product);

    try
    {

        // Display the created product details
        Console.WriteLine($"Product created successfully! Product ID: {createdProduct.ProductId}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating the product: {ex.Message}");
    }
}

await Main();
Console.WriteLine("Hello, World!");