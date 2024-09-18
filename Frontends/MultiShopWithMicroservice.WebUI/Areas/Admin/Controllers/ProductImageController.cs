using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDtos;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShopWithMicroservice.WebUI.ResultMessage;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class ProductImageController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;


        public ProductImageController(IToastNotification toastNotification, IProductImageService productImageService, IProductService productService)
        {
            _toastNotification = toastNotification;
            _productImageService = productImageService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetImagesByProductId(string id)
        {
             ProductImageViewbagList();
            var values = await _productImageService.GetImagesByProductId(id); 
            
            return View(values);
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
        {
            var productList = await _productService.GetAllProductsAsync();
            ViewBag.ProductList = (from x in productList
                                   select new SelectListItem
                                      {
                                          Text = x.ProductName,
                                          Value = x.ProductId
                                      }).ToList();

            ProductImageViewbagList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            PictureProductList();

            

            foreach (var file in createProductImageDto.MultiFile)
            {
                if (file.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await file.CopyToAsync(stream);
                    }
                    createProductImageDto.ImageUrl = $"/uploads/"+uniqueFileName;
                    await _productImageService.CreateProductImageAsync(createProductImageDto);
                 
                    _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createProductImageDto.ProductId), new ToastrOptions { Title = "Success" });
                    
                }
            }
            return RedirectToAction("Index", "Product", new { Area = "Admin" } );
        }


        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
           
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Deleted Successfully" });
            return RedirectToAction("Index", "Product", new { Area = "Admin" });
          
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            ProductImageViewbagList();


            PictureProductList();

            var value=await _productImageService.GetByIdProductImageAsync(id);

            return View(value);
           
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateProductImageDto.ProductId), new ToastrOptions { Title = "Successfully updated" });
            return RedirectToAction("Index", "Product", new { Area = "Admin" });
          
        }

        public async void PictureProductList()
        {
            #region Product
            var productList = await _productService.GetAllProductsAsync();
            ViewBag.ProductList = (from x in productList
                                   select new SelectListItem
                                   {
                                       Text = x.ProductName,
                                       Value = x.ProductId
                                   }).ToList();
            #endregion
        }
        void ProductImageViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product Images";
            ViewBag.v3 = "ProductImageList";
            ViewBag.v0 = "ProductImage Operations";
        }
    }
}
