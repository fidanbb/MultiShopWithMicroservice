using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;
using X.PagedList.Extensions;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController( IProductService productService, ICategoryService categoryService)
        {
       
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            ProductViewbagList();
            var values = await _productService.GetProductsWithCategoryAsync();
            int pageSize = 5;
            var pagedValues = values.ToPagedList(page, pageSize);
            int pagedCount = (pageSize * (page - 1));
            ViewBag.PageSize = pagedCount;

            return View(pagedValues);
        }

      

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewbagList();

            var categoryList = await _categoryService.GetAllCategoryAsync();
            ViewBag.CategoryValues = (from x in categoryList
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.CategoryID
                                }).ToList();
            
            return View();
        }

        [HttpPost]
     
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            await _productService.CreateProductAsync(createProductDto);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);

           return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewbagList();
            var categoryList = await _categoryService.GetAllCategoryAsync();
            ViewBag.CategoryValues = (from x in categoryList
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.CategoryID
                                }).ToList();


            var values = await _productService.GetProductByIdAsync(id);
            return View(values);
          
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
           
            return RedirectToAction("Index", "Product", new { area = "Admin" });
          
        }

        void ProductViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "ProductList";
            ViewBag.v0 = "Product Operations";
        }
    }
}
