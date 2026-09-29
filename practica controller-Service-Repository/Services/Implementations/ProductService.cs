using practica_controller_Service_Repository.Models.DTOS.Responses;
using practica_controller_Service_Repository.Repositories.Implementations;

namespace practica_controller_Service_.Services.Implementations;

public class ProductService
{
    private ProductRepository _repository = new ProductRepository();

    public List GetAllProducts()
    {
        return _repository.GetAllProduct()
            .Select(p => new ProductForReadDto { Id = p.Id, Name = p.Name, Price = p.Price })
            .ToList();

    }

    public ProductForReadDto? GetProductById(int id)
    {
        var product = _repository.GetProductById(id);
        if (product == null) return null;

        return new ProductForReadDto { Id = product.Id, Name = product.Name, Price = product.Price };
    }

    public ProductForReadDto CreateProduct(ProductForReadDto dto)
    {
        var product = new ProductForReadDto { Name = dto.Name, Price = dto.Price };
        _repository.AddProduct(product);

        return new ProductForReadDto { Id = product.Id, Name = product.Name, Price = product.Price };
    }

    public void UpdateProduct(int id, ProductForReadDto dto)
    {
        var product = new ProductForReadDto { Id = id, Name = dto.Name, Price= dto.Price };
        _repository.UpdateProduct(product);
    }

    public void DeleteProduct(int id)
    {
        var product = _repository.GetProductById(id);
        if (product != null)
        {
            _repository.DeleteProduct(product);
        }
    }
}