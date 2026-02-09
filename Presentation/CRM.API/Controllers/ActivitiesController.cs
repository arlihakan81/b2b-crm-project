using CRM.Application.DTOs.ActivityDTOs;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController(IActivityService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDTO>>> GetAll()
            => await service.GetAllAsync() is null ? new List<ActivityDTO>() : Ok(await service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDTO>> Get(Guid id)
            => await service.GetAsync(id) is null ? NotFound("Öğe bulunamadı") : Ok(await service.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActivityDTO createActivityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(createActivityDTO);
            await service.CreateAsync(createActivityDTO);
            return Created(nameof(Get), createActivityDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateActivityDTO updateActivityDTO)
        {
            await service.UpdateAsync(id, updateActivityDTO);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return Ok("Silindi");
        }


    }
}
