namespace practica_controller_Service_Repository.Models.DTOS.Requests;

public class ProductForCreateDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}