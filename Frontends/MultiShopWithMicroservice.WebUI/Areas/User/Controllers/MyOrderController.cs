using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;
using MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderDetailServices;
using MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShopWithMicroservice.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderOrderingService orderOrderingService, IUserService userService, IOrderDetailService orderDetailService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
            _orderDetailService = orderDetailService;
        }
        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderOrderingService.GetOrderingByUserId(user.Id);
            return View(values);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var values = await _orderDetailService.GetOrderDetailByOrderingIdAsync(id);
            return View(values);
        }
    }
}
