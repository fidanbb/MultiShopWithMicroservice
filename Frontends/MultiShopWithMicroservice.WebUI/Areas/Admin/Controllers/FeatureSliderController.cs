using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController( IFeatureSliderService featureSliderService)
        {
        
            _featureSliderService = featureSliderService;
        }
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewbagList();
            var values=await _featureSliderService.GetAllFeatureSliderAsync();
           
            return View(values);
          
        }

        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            FeatureSliderViewbagList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
           
        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
          
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
          
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderViewbagList();

            var value=await _featureSliderService.GetByIdFeatureSliderAsync(id);
            
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
         
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

        }

        void FeatureSliderViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Feature Sliders";
            ViewBag.v3 = "FeatureSldierList";
            ViewBag.v0 = "Feature Slider Operations";
        }
    }
}
