using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IHttpClientFactory _httpClientFactory;
        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();

            if (id == null)
            {
               var values=await _productService.GetProductsWithCategoryAsync();
              
               return View(values);
               
            }
            
             var products=await _productService.GetProductsByCategoryIdAsync(id);
             var category=await _categoryService.GetByIdCategoryAsync(id);

             ViewBag.ct = products.Count > 0 ? "Products in " + category.CategoryName + " Category" : category.CategoryName + " Category dont'have any product yet.";
             return View(products);
             
        }
    }
}
