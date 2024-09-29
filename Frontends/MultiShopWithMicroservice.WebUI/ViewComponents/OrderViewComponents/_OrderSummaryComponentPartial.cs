using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.WebUI.Services.BasketServices;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasketAsync();
            return View(values);
        }
    }
}
