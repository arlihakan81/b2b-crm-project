using CRM.Application.Interfaces;
using CRM.Application.Requests.Activities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivitiesController(IActivityService service) : ControllerBase
    {
        private readonly IActivityService service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        [HttpGet("{id}")]   
        public async Task<IActionResult> Get(Guid id) => Ok(await service.GetByIdAsync(id));

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetByAccountId(Guid accountId) => Ok(await service.GetByAccountIdAsync(accountId));

        [HttpGet("deal/{dealId}")]
        public async Task<IActionResult> GetByDealId(Guid dealId) => Ok(await service.GetByDealIdAsync(dealId));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActivityRequest request)
        {
            try
            {
                await service.CreateAsync(request);
                return Ok("Etkinlik kaydı başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateActivityRequest request)
        {
            try
            {
                await service.UpdateAsync(id, request);
                return Ok("Etkinlik güncelleme başarılı");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
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
                return Ok("Etkinlik silme başarılı");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
