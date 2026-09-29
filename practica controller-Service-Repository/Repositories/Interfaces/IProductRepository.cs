using PracticaIntegrada.Entities;

namespace practica_controller_Service_Repository.Repositories.interfaces;

public interface IProductRepository
{
    List GetAllProduct();
    Product? GetProductById(int id);
    void AddProduct(Product product);
    void updateProduct(Product product);
    void DeleteProduct(Product product);


}
