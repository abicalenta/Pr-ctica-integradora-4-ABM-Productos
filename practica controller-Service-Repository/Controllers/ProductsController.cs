using Microsoft.AspNetCore.Mvc;
using practica_controller_Service_Repository.Models.DTOS.Requests;
using practica_controller_Service_Repository.Models.DTOS.Responses;
using practica_controller_Service_Repository.Services.Interfaces;


namespace practica_controller_Service_Repository.Controllers
{
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
        public ActionResult<List<ProductForReadDto>> GetAll()
        {
            return Ok(_service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductForReadDto> GetById(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductForReadDto> Create(ProductForCreateDto dto)
        {
            if (_service.ExistsByName(dto.Name))
            {
                return Conflict($"Ya existe un producto con el nombre '{dto.Name}'.");
            }

            var createdProduct = _service.CreateProduct(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductForUpdateDto dto)
        {
            var existingProduct = _service.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (_service.ExistsByName(dto.Name, excludeId: id))
            {
                return Conflict($"Ya existe un producto con el nombre '{dto.Name}'.");
            }

            _service.UpdateProduct(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _service.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _service.DeleteProduct(id);
            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<List<ProductForReadDto>> Search([FromQuery] string name)
        {
            var results = _service.SearchProductsByName(name ?? string.Empty);
            return Ok(results);
        }

        [HttpGet("stats")]
        public ActionResult<ProductStatsDto> GetStats()
        {
            return Ok(_service.GetStats());
        }
    }
}