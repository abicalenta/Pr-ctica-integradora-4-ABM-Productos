using practica_controller_Service_Repository.Models.DTOS.Requests;
using practica_controller_Service_Repository.Models.DTOS.Responses;
using TuProyecto.Models.DTOs.Requests;
using TuProyecto.Models.DTOs.Responses;

namespace practica_controller_Service_Repository.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductForReadDto> GetAllProducts();
        ProductForReadDto? GetProductById(int id);
        ProductForReadDto CreateProduct(ProductForCreateDto dto);
        void UpdateProduct(int id, ProductForUpdateDto dto);
        void DeleteProduct(int id);
        List<ProductForReadDto> SearchProductsByName(string name);
        ProductStatsDto GetStats();
        bool ExistsByName(string name, int? excludeId = null);
    }
}