using CRM.Application.Interfaces;
using CRM.Application.Requests.Deals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class DealsController(IDealService service) : ControllerBase
    {
        readonly IDealService service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDealRequest request)
        {
            try
            {
                await service.CreateAsync(request);
                return Ok("Yeni satış fırsatı kaydedildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateDealRequest request)
        {
            try
            {
                await service.UpdateAsync(id, request);
                return Ok("Satış fırsatı güncellendi");
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
                return Ok("Satış fırsatı silindi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






    }
}
