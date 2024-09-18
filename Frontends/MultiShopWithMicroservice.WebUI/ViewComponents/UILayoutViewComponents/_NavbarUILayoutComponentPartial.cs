﻿using Microsoft.AspNetCore.Mvc;
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
        public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
        {
     
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
			var values=await _categoryService.GetAllCategoryAsync();

            return View(values);
        }
    }
}
