namespace practica_controller_Service_Repository.Models.DTOS.Responses;

public class ProductForReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
