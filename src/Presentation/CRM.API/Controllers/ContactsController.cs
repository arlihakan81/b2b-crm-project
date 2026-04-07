using CRM.Application.Interfaces;
using CRM.Application.Requests.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController(IContactService service) : ControllerBase
    {
        readonly IContactService service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await service.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactRequest request)
        {
            try
            {
                await service.CreateAsync(request);
                return Ok("Yeni kişi başarıyla kaydedildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateContactRequest request)
        {
            try
            {
                await service.UpdateAsync(id, request);
                return Ok("Kişi başarıyla güncellendi");
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
                return Ok("Kişi başarıyla silindi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }














    }
}
