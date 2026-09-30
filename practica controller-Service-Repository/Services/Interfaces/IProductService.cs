using practica_controller_Service_Repository.Models.DTOs.Requests;
using practica_controller_Service_Repository.Models.DTOs.Responses;
using practica_controller_Service_Repository.Models.DTOS.Requests;
using practica_controller_Service_Repository.Models.DTOS.Responses;

namespace practica_controller_Service_Repository.Services.Interfaces;

public interface IProductService
{
    List GetAllProducts();
    ProductForReadDto? GetProductById(int id);
    ProductForReadDto CreateProduct(ProductForCreateDto dto);
    void UpdateProduct(int id, ProductForUpdateDto dto);
    void DeleteProduct(int id);
    List SearchProductByName(string name);
    ProductStatsDto GetStats();
}