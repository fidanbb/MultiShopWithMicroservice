using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
