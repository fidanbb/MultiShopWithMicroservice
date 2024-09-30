using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
