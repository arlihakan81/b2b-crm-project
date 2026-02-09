using CRM.Application.DTOs.DealTypeDTOs;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealTypesController(IDealTypeService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealTypeDTO>>> GetAll()
        {
            var dealTypes = await service.GetAllAsync();
            return dealTypes is null ? new List<DealTypeDTO>() : Ok(dealTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DealTypeDTO>> Get(Guid id)
        {
            var dealType = await service.GetAsync(id);
            return dealType is null ? NotFound() : Ok(dealType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDealTypeDTO createDealTypeDTO)
        {
            if (!await service.IsNameUniqueAsync(createDealTypeDTO.Name))
                return BadRequest("A deal type with the same name already exists in the organization.");

            await service.CreateAsync(createDealTypeDTO);
            return Created(nameof(Get), createDealTypeDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDealTypeDTO updateDealTypeDTO)
        {
            if (!await service.IsNameUniqueAsync(updateDealTypeDTO.Name, id))
                return BadRequest("A deal type with the same name already exists in the organization.");

            await service.UpdateAsync(id, updateDealTypeDTO);
            return Ok("Güncelleme başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }










    }
}
