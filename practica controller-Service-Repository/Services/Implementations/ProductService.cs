using practica_controller_Service_Repository.Entities;
using practica_controller_Service_Repository.Models.DTOS.Requests;
using practica_controller_Service_Repository.Models.DTOS.Responses;
using practica_controller_Service_Repository.Repositories.Interfaces;
using practica_controller_Service_Repository.Services.Interfaces;
using TuProyecto.Models.DTOs.Requests;
using TuProyecto.Models.DTOs.Responses;

namespace practica_controller_Service_Repository.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<ProductForReadDto> GetAllProducts()
        {
            return _repository.GetAllProducts()
                .Select(p => MapToReadDto(p))
                .ToList();
        }

        public ProductForReadDto? GetProductById(int id)
        {
            var product = _repository.GetProductById(id);
            return product == null ? null : MapToReadDto(product);
        }

        public ProductForReadDto CreateProduct(ProductForCreateDto dto)
        {
            var entity = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            var createdProduct = _repository.AddProduct(entity);
            return MapToReadDto(createdProduct);
        }

        public void UpdateProduct(int id, ProductForUpdateDto dto)
        {
            var entity = _repository.GetProductById(id);
            if (entity != null)
            {
                entity.Name = dto.Name;
                entity.Price = dto.Price;
                _repository.UpdateProduct(entity);
            }
        }

        public void DeleteProduct(int id)
        {
            var entity = _repository.GetProductById(id);
            if (entity != null)
            {
                _repository.DeleteProduct(entity);
            }
        }

        public List<ProductForReadDto> SearchProductsByName(string name)
        {
            return _repository.SearchProductsByName(name)
                .Select(p => MapToReadDto(p))
                .ToList();
        }

        public ProductStatsDto GetStats()
        {
            var products = _repository.GetAllProducts();

            if (!products.Any())
            {
                return new ProductStatsDto
                {
                    Total = 0,
                    AveragePrice = 0,
                    MostExpensiveName = string.Empty
                };
            }

            return new ProductStatsDto
            {
                Total = products.Count,
                AveragePrice = products.Average(p => p.Price),
                MostExpensiveName = products.OrderByDescending(p => p.Price).FirstOrDefault()?.Name ?? string.Empty
            };
        }

        public bool ExistsByName(string name, int? excludeId = null)
        {
            return _repository.GetAllProducts().Any(p =>
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || p.Id != excludeId.Value));
        }

        private static ProductForReadDto MapToReadDto(Product product)
        {
            return new ProductForReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}