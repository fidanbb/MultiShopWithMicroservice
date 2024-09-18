using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class OfferDiscountController : Controller
    {
          private readonly IOfferDiscountService  _offerDiscountService;
        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
        
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IActionResult> Index()
        {
            OfferDiscountViewbagList();

            var values=await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }

        void OfferDiscountViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "OfferDiscounts";
            ViewBag.v3 = "OfferDiscountList";
            ViewBag.v0 = "OfferDiscount Operations";
        }

        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewbagList();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        
        }

        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);    
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewbagList();

            var value=await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
           
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
          
        }
    }
}
