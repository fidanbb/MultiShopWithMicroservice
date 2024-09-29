using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.WebUI.Models;
using MultiShopWithMicroservice.WebUI.Services.BasketServices;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartDiscountCouponComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? couponCode)
        {

            var basket = await _basketService.GetBasketAsync();


            var result = new BasketCouponViewModel
            {
                BasketTotalDto = basket,
            };
            return View(result);
        }
    }
}
