using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    [AllowAnonymous]
    public class InformationController : Controller
    {
        private readonly IStringLocalizer<InformationController> _localizer;

        public InformationController(IStringLocalizer<InformationController> localizer)
        {
            _localizer = localizer;
        }
        [HttpPost]
        public IActionResult Index(string culture, string returnUrl)
        {
            string x=returnUrl;
            return LocalRedirect(returnUrl);
        }
    }
}
