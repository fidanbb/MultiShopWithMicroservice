using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<_NavbarUILayoutComponentPartial> _localizer;
        public _NavbarUILayoutComponentPartial(ICategoryService categoryService, IStringLocalizer<_NavbarUILayoutComponentPartial> localizer)
        {

            _categoryService = categoryService;
            _localizer = localizer;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
			var values=await _categoryService.GetAllCategoryAsync();

            return View(values);
        }
    }
}
