using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpeacialOfferComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
