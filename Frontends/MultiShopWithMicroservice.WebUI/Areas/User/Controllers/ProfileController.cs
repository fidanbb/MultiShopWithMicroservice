﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopWithMicroservice.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
