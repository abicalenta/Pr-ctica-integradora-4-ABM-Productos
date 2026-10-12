using practica_controller_Service_Repository.Entities;

namespace practica_controller_Service_Repository.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        Product AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> SearchProductsByName(string name);
    }
}