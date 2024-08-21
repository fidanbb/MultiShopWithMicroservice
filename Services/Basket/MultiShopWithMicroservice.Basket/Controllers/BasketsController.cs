using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Basket.Dtos;
using MultiShopWithMicroservice.Basket.LoginServices;
using MultiShopWithMicroservice.Basket.Services;

namespace MultiShopWithMicroservice.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]

        public async Task<IActionResult> GetBasketDetail()
        {
            var user = User.Claims;

            //var userId = _loginService.GetUserId;

            var values = await _basketService.GetBasketAsync(_loginService.GetUserId);

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserID = _loginService.GetUserId;

            await _basketService.SaveBasketAsync(basketTotalDto);

            return Ok("Changes in basket saved");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasketAsync(_loginService.GetUserId);

            return Ok("Basket deleted successfully");
        }
    }
}
