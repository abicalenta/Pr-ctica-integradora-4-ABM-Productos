using practica_controller_Service_.Services.Implementations;
using practica_controller_Service_Repository.Models.DTOS.Requests;

namespace practica_controller_Service_Repository.Controllers

[ApiController]
[Route("api/[controller])")]

public class ProductsController : ControllerBase
{
    private IProductService _service = new IProductService();
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllProducts());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetProductById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductForCreateDto dto)
    {
        var createdProduct = _service.CreateProduct(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ProductForUpdateDto dto)
    {
        var existing = _service.GetProductById(id);
        if (existing == null) return NotFound();

        _service.UpdateProduct(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existing = _service.GetProductById(id);
        if (existing == null) return NotFound();

        _service.DeleteProduct(id);
        return NoContent();
    }
}