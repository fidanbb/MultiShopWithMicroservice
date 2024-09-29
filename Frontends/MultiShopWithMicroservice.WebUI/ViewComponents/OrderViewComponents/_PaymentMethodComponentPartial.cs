using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethodComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
