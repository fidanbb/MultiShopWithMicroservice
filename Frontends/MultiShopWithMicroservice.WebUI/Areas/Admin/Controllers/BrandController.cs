using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.BrandDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;
using X.PagedList.Extensions;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            BrandViewbagList();
            var values =await _brandService.GetAllBrandAsync();
            int pageSize = 5;
            var pagedValues = values.ToPagedList(page, pageSize);
            int pagedCount = (pageSize * (page - 1));
            ViewBag.PageSize = pagedCount;

            return View(pagedValues);
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            BrandViewbagList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
       
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
           
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
         
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            BrandViewbagList();
           var value=await _brandService.GetByIdBrandAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
           
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
            
        }

        void BrandViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Brands";
            ViewBag.v3 = "BrandList";
            ViewBag.v0 = "Brand Operations";
        }
    }
}
