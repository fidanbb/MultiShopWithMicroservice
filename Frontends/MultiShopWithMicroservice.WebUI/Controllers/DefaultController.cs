using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            var user = User.Claims;
            
            return View();
        }
    }
}
