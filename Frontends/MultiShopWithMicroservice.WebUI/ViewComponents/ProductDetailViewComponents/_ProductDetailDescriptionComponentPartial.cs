using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

      
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value=await _productDetailService.GetProductDetailByProductIdAsync(id);
          
            return View(value);
        }
    }
}
