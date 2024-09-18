using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _FeatureProductsDefaultComponentPartial(IProductService productService)
        {
        
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _productService.GetAllProductsAsync();
            
            return View(values);
        }
    }
}
