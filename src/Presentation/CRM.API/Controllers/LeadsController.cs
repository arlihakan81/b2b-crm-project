using CRM.Application.Interfaces;
using CRM.Application.Requests.Leads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class LeadsController(ILeadService service) : ControllerBase
    {
        readonly ILeadService service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        [HttpGet("{id}")]   
        public async Task<IActionResult> Get(Guid id) => Ok(await service.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeadRequest request)
        {
            try
            {
                await service.CreateAsync(request);
                return Ok("Yeni müşteri adayınız kaydedildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateLeadRequest request)
        {
            try
            {
                await service.UpdateAsync(id, request);
                return Ok("Müşteri adayınız güncellendi");
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
                return Ok("Müşteri adayınız silindi");
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
