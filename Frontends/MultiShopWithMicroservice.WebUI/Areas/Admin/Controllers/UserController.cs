using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
        {
            _userService = userService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> UserList()
        {
            var values = await _userService.GetAllUsers();
            return View(values);
        }

        public async Task<IActionResult> AddressDetailByUserId(string id)
        {
            var values = await _cargoCustomerService.GetDetailsByUserIdAsync(id);
            return View(values);
        }

    }
}
