using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;
        public SpecialOfferController( ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewbagList();

            var values=await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
          
        }

        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewbagList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
          
        }

        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewbagList();

            var value=await _specialOfferService.GetByIdSpecialOfferAsync(id);

            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
           
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
           
        }

        void SpecialOfferViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Special Offers";
            ViewBag.v3 = "SpecialOfferList";
            ViewBag.v0 = "Special Offer Operations";
        }
    }
}
