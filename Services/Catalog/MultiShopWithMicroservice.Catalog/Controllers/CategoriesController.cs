using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Catalog.Dtos.CategoryDtos;
using MultiShopWithMicroservice.Catalog.Services.CategoryServices;

namespace MultiShopWithMicroservice.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            return Ok(await _categoryService.GetAllCategoryAsync());
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);

            return Ok("Category added successfully");
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return Ok("Category deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            return Ok(await _categoryService.GetByIdCategoryAsync(id));
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);

            return Ok("Category updated successfully");
        }
    }
}
