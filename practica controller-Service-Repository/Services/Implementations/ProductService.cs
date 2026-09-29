using practica_controller_Service_Repository.Models.DTOS.Responses;
using practica_controller_Service_Repository.Repositories.Implementations;

namespace practica_controller_Service_.Services.Implementations;

public class IProductService
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

    public List SearchProductByName(string name)
    {
        return _repository.SearchProductByName(name)
            .Select(p => new ProductForReadDto { Id = p.Id, Name = p.Name, Price = p.Price })
            .ToList();
    }

    public ProductStatsDto GetStats()
    {
        var products = _repository.GetAllProducts();
        if (products.Count == 0)
        {
            return new ProductStatsDto { Total = 0, AveragePrice = 0, MostExpensiveName = string.Empty };
        }

        return new ProductStatsDto
        {
            Total = products.Count,
            AveragePrice = products.Average(p => p.Price),
            MostExpensiveName = products.OrderByDescending(p => p.Price).First().Name
        };
    }

}