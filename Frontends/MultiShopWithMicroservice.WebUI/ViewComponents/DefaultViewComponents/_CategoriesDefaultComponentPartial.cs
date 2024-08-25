using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
