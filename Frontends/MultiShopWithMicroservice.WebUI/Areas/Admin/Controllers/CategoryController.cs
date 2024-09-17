using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;
using X.PagedList.Extensions;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;
        public CategoryController(IHttpClientFactory httpClientFactory,ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            CategoryViewbagList();

            var values=await _categoryService.GetAllCategoryAsync();
            int pageSize = 5;
            var pagedValues = values.ToPagedList(page, pageSize);
            int pagedCount = (pageSize * (page - 1));
            ViewBag.PageSize = pagedCount;

            return View(pagedValues);      
        }

        void CategoryViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "CategoryList";
            ViewBag.v0 = "Category Operations";
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            CategoryViewbagList();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            await _categoryService.CreateCategoryAsync(createCategoryDto);

           
                return RedirectToAction("Index", "Category", new { area = "Admin" });
          
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);

           
                return RedirectToAction("Index", "Category", new { area = "Admin" });
          
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewbagList();
            var value=await _categoryService.GetByIdCategoryAsync(id);
         
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
           
                return RedirectToAction("Index", "Category", new { area = "Admin" });
           
        }
    }
}
