using CRM.Application.DTOs.CategoryDTOs;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll() => await service.GetAllAsync() is IEnumerable<CategoryDTO> categories
            ? Ok(categories)
            : NotFound();

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> Get(Guid id) => await service.GetAsync(id) is CategoryDTO category
            ? Ok(category)
            : NotFound();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDTO dto)
        {
            if (dto == null)
                return BadRequest();
            if(!await service.IsCategoryNameUniqueAsync(dto.Name, null))
                return Conflict($"Category with name '{dto.Name}' already exists in the organization.");
            await service.CreateAsync(dto);
            return Created(nameof(Get), dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDTO dto)
        {
            if (dto == null)
                return BadRequest();
            if (!await service.IsCategoryNameUniqueAsync(dto.Name, id))
                return Conflict($"Category with name '{dto.Name}' already exists in the organization.");
            await service.UpdateAsync(id, dto);
            return Ok("Öğe güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await service.GetAsync(id);
            if (category == null)
                return NotFound();
            await service.DeleteAsync(id);
            return Ok("Öğe silindi");
        }










    }
}
