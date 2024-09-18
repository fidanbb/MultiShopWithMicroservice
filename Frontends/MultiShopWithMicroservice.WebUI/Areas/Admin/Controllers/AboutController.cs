using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.AboutDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
  
    public class AboutController : Controller
    {
       private readonly IAboutService _aboutService;
        public AboutController( IAboutService aboutService)
        {
         
            _aboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {
            AboutViewbagList();

            var values=await _aboutService.GetAllAboutAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            AboutViewbagList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
           
            return RedirectToAction("Index", "About", new { area = "Admin" });
            
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            AboutViewbagList();
            var value=await _aboutService.GetByIdAboutAsync(id);
        
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
          
            return RedirectToAction("Index", "About", new { area = "Admin" });
         
        }

        void AboutViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "AboutList";
            ViewBag.v0 = "About Operations";
        }
    }
}
