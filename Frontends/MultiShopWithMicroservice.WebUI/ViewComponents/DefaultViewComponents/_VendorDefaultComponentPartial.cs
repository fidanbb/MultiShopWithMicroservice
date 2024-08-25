using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
