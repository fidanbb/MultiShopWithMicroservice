using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
