﻿using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.AboutDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;
   
        public _FooterUILayoutComponentPartial(IAboutService aboutService)
        {
          _aboutService = aboutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
			var values=await _aboutService.GetAllAboutAsync();

            return View(values.FirstOrDefault());
           
        }
    }
}
