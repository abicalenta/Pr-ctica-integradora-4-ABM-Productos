using Microsoft.AspNetCore.Mvc;
using practica_controller_Service_Repository.Models.DTOS.Requests;
using practica_controller_Service_Repository.Services.Interfaces;

namespace practica_controller_Service_Repository.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

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
        try
        {
            var createdProduct = _service.CreateProduct(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
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


    [HttpGet("stats")]
    public IActionResult GetStats()
    {
        return Ok(_service.GetStats());
    }
}