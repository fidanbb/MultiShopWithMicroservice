using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
