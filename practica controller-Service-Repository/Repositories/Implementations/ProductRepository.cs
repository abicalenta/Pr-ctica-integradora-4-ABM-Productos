namespace practica_controller_Service_Repository.Repositories.Implementations;

public class ProductRepository
{
    private static List _products = new()
    {
        new Product { Id = 1, Name = "Mouse inalambrico", Price = 3999.99m },
        new Product { Id = 2, Name = "Teclado inalambrico", Price = 8299.50m },
        new Product { Id = 3, Name = "Monitor 24 pulgadas", Price = 52499.00m },
        new Product { Id = 4, Name = "Notebook Dell Inspiron", Price = 185000.00m },
        new Product { Id = 5, Name = "Auriculares Bluetooth", Price = 10499.90m },
        new Product { Id = 6, Name = "Webcam HD", Price = 7999.009m },
        new Product { Id = 7, Name = "Silla ergonomica", Price = 61200.00m },
        new Product { Id = 8, Name = "Disco SSD 1TB", Price = 44999.99m },
        new Product { Id = 9, Name = "tablet samsung", Price = 93499.00m },
        new Product { Id = 10, Name = "Impresora multifuncion", Price = 73900.00m },

    };
}