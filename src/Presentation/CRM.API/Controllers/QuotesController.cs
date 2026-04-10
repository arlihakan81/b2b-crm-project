using CRM.Application.Interfaces;
using CRM.Application.Requests.Quotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class QuotesController(IQuoteService service) : ControllerBase
    {
        private readonly IQuoteService service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateQuoteRequest request)
        {
            try
            {
                await service.CreateAsync(request);
                return Ok("Yeni teklifiniz kaydedildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateQuoteRequest request)
        {
            try
            {
                await service.UpdateAsync(id, request);
                return Ok("Teklifiniz güncellendi");
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
                return Ok("Teklifiniz silindi");
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
