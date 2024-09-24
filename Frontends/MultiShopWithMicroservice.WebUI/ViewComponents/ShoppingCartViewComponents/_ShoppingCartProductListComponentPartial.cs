using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.WebUI.Services.BasketServices;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartProductListComponentPartial(IBasketService basketService)
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
