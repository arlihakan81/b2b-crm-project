using CRM.Application.Interfaces;
using CRM.Application.Requests.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController(IAccountService service) : ControllerBase
    {
        readonly IAccountService service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await service.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
        {
            try
            {
                await service.CreateAsync(request);
                return Ok("Yeni hesap başarıyla kaydedildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAccountRequest request)
        {
            try
            {
                await service.UpdateAsync(id, request);
                return Ok("Hesap başarıyla güncellendi");
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
                return Ok("Hesap başarıyla silindi");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }






    }
}
