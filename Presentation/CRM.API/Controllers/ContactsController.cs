using CRM.Application.DTOs.ContactDTOs;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAll()
        {
            var result = await service.GetAllAsync();
            if (result is null)
                return new List<ContactDTO>();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDTO>> Get(Guid id)
        {
            var result = await service.GetAsync(id);
            if (result is null)
                return NotFound("Kişi bilgisi bulunamadı");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await service.IsEmailUniqueAsync(dto.Email, null))
            {
                return BadRequest("Bu e-posta adresi zaten kullanılıyor");
            }
            if (dto.Mobile is not null && !await service.IsMobileUniqueAsync(dto.Mobile, null))
            {
                return BadRequest("Bu telefon numarası zaten kullanılıyor");
            }

            await service.CreateAsync(dto);
            return Created(nameof(Get), dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateContactDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await service.IsEmailUniqueAsync(dto.Email, id))
            {
                return BadRequest("Bu e-posta adresi zaten kullanılıyor");
            }
            if (dto.Mobile is not null && !await service.IsMobileUniqueAsync(dto.Mobile, id))
            {
                return BadRequest("Bu telefon numarası zaten kullanılıyor");
            }

            await service.UpdateAsync(id, dto);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var contact = await service.GetAsync(id);
            if (contact is null)
            {
                return NotFound("Öğe bulunamadı");
            }
            await service.DeleteAsync(id);
            return Ok("Silme işlemi başarılı");

        }















    }
}
