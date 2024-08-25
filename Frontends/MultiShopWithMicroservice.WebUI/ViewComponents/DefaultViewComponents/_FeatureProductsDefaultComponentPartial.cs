using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
