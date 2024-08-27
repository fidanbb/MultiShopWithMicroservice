using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
