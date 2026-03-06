using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementApi.DTOs;
using ProductManagementApi.Interfaces;
using ProductManagementApi.Models;

namespace ProductManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) { 
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductCreateDto dto)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }
            var id = await _productService.Add(dto);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            //if (!ModelState.IsValid) { return BadRequest(ModelState);
            var result = await _productService.Update(id, dto);
            if(!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if ((!result))  return NotFound();
            return NoContent();
        }
    }
}
