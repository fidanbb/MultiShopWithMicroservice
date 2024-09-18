using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class ProductDetailController : Controller
    {
     
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
     
            _productDetailService = productDetailService;
        }


        public async Task<IActionResult> Index(string id)
        {
            ProductDetailViewbagList();

            TempData["productId"] = id;
            ViewBag.productId =id;

            var value=await _productDetailService.GetProductDetailByProductIdAsync(id);
          

            return View(value);
        }

        [HttpGet]
        public IActionResult CreateProductDetail()
        {
            
            ProductDetailViewbagList();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            createProductDetailDto.ProductId = TempData["productId"].ToString();

            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);

           
            return RedirectToAction("Index", "Product", new { area = "Admin" });
           
        }

        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
           
            return RedirectToAction("Index", "Product", new { area = "Admin" });
         
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ProductDetailViewbagList();

            var value=await _productDetailService.GetProductDetailByIdAsync(id);
           
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
          
            return RedirectToAction("Index", "Product", new { area = "Admin" });
           
        }

        void ProductDetailViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "ProductDetails";
            ViewBag.v3 = "ProductDetailList";
            ViewBag.v0 = "ProductDetail Operations";
        }

       
    }
}
