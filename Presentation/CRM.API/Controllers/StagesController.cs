using CRM.Application.DTOs.StageDTOs;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagesController(IStageService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StageDTO>>> GetAll()
        {
            var stages = await service.GetAllAsync();
            return stages is null ? new List<StageDTO>() : Ok(stages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StageDTO>> Get(Guid id)
        {
            return await service.GetAsync(id) is null ? NotFound("Öğe bulunamadı") : Ok(await service.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStageDTO createStageDTO)
        {
            if (!await service.IsStageNameUniqueAsync(createStageDTO.Name))
                return BadRequest("A stage with the same name already exists in the organization.");

            await service.CreateAsync(createStageDTO);
            return Created(nameof(Get), createStageDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateStageDTO updateStageDTO)
        {
            if (!await service.IsStageNameUniqueAsync(updateStageDTO.Name, id))
                return BadRequest("A stage with the same name already exists in the organization.");

            await service.UpdateAsync(id, updateStageDTO);
            return Ok("Güncelleme başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return Ok("Silindi");
        }





    }
}
