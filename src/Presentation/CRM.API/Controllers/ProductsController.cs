using CRM.Application.Interfaces;
using CRM.Application.Requests.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController(IProductService service) : ControllerBase
    {
        readonly IProductService service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest request)
        {
            try
            {
                await service.CreateAsync(request);
                return Ok("Yeni ürün başarıyla kaydedildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductRequest request)
        {
            try
            {
                await service.UpdateAsync(id, request);
                return Ok("Ürün başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await service.DeleteAsync(id);
                return Ok("Ürün başarıyla silindi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
