using CRM.Application.DTOs.LeadDTOs;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController(ILeadService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadDTO>>> GetAll()
             => await service.GetAllAsync() is IEnumerable<LeadDTO> leads ? Ok(leads) : NotFound();

        [HttpGet("{id}")]
        public async Task<ActionResult<LeadDTO>> Get(Guid id)
             => await service.GetAsync(id) is LeadDTO lead ? Ok(lead) : NotFound();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLeadDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await service.IsEmailUniqueAsync(dto.Email, null))
                return Conflict("Email must be unique.");
            if(dto.Mobile is not null)
            {
                if (!await service.IsMobileUniqueAsync(dto.Mobile, null))
                    return Conflict("Mobile must be unique.");
            }

            if (dto.Phone is not null)
            {
                if (!await service.IsPhoneUniqueAsync(dto.Phone, null))
                    return Conflict("Phone must be unique.");
            }
            await service.CreateAsync(dto);
            return Created(nameof(Get), dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLeadDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await service.IsEmailUniqueAsync(dto.Email, id))
                return Conflict("Email must be unique.");
            if (dto.Mobile is not null)
            {
                if (!await service.IsMobileUniqueAsync(dto.Mobile, id))
                    return Conflict("Mobile must be unique.");
            }

            if (dto.Phone is not null)
            {
                if (!await service.IsPhoneUniqueAsync(dto.Phone, id))
                    return Conflict("Phone must be unique.");
            }

            await service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var lead = await service.GetAsync(id);
            if (lead is null)
                return NotFound();
            await service.DeleteAsync(id);
            return Ok("Öğe başarıyla silindi");
        }


















    }
}
