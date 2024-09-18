using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpeacialOfferComponentPartial : ViewComponent
    {
       private readonly ISpecialOfferService _specialOfferService;

        public _SpeacialOfferComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _specialOfferService.GetAllSpecialOfferAsync();
            
            return View(values);
        }
    }
}
