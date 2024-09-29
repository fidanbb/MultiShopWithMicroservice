using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;
using MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            ViewBag.directory1 = "Multishop";
            ViewBag.directory2 = "Orders";
            ViewBag.directory3 = "Order Operaations";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAddress([FromBody] CreateOrderAddressDto request)
        {
            var values = await _userService.GetUserInfo();
            request.UserId = values.Id;
            await _orderAddressService.CreateOrderAddressAsync(request);
            return RedirectToAction(nameof(OrderController.Index), "Order");
        }

    }
}
