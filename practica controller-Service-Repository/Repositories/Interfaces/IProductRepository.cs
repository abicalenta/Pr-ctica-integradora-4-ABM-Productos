using practica_controller_Service_Repository.Entities;
using PracticaIntegrada.Entities;

namespace practica_controller_Service_Repository.Repositories.interfaces;

public interface IProductRepository
{
    List GetAllProducts();
    Product? GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    List SearchProductsByName(string name);
}
