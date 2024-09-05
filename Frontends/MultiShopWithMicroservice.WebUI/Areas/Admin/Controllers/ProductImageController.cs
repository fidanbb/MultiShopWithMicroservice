using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDtos;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShopWithMicroservice.WebUI.ResultMessage;
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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public ProductImageController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> GetImagesByProductId(string id)
        {
             ProductImageViewbagList();

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/ProductImages/GetImagesByProductID/"+id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            List<SelectListItem> productValue = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ProductName,
                                                     Value = x.ProductId.ToString()
                                                 }).ToList();
            ViewBag.ProductList = productValue;
            ProductImageViewbagList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            PictureProductList();
            var client = _httpClientFactory.CreateClient();

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
                    var jsonData = JsonConvert.SerializeObject(createProductImageDto);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                 

                    var responseMessage = await client.PostAsync("https://localhost:7070/api/ProductImages", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createProductImageDto.ProductId), new ToastrOptions { Title = "Success" });
                    }
                }
            }
            return RedirectToAction("Index", "Product", new { Area = "Admin" } );
        }


        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/ProductImages?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Deleted Successfully" });
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            ProductImageViewbagList();


            PictureProductList();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImages/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductImages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateProductImageDto.ProductId), new ToastrOptions { Title = "Successfully updated" });
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return View();
        }

        public async void PictureProductList()
        {
            #region Product
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            List<SelectListItem> productValue = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ProductName,
                                                     Value = x.ProductId.ToString()
                                                 }).ToList();
            ViewBag.ProductList = productValue;
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
