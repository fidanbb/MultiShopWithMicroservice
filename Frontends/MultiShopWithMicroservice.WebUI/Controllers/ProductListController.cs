using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.categoryId = id;
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
