using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class FeatureController : Controller
    {
       private readonly IFeatureService _featureService;
        public FeatureController( IFeatureService featureService)
        {
            
            _featureService = featureService;
        }
        public async Task<IActionResult> Index()
        {
            FeatureViewbagList();
            var values=await _featureService.GetAllFeatureAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            FeatureViewbagList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
           
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
            
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
           
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeatureViewbagList();

            var value=await _featureService.GetByIdFeatureAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
          
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
         
        }

        void FeatureViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Features";
            ViewBag.v3 = "FeatureList";
            ViewBag.v0 = "Feature Operations";
        }
    }
}
