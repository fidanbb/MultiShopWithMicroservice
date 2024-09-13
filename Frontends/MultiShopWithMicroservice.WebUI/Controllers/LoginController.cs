using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.IdentityDtos;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly HttpClient _client;
		private readonly IIdentityService _identityService;
		public LoginController(HttpClient client, IIdentityService identityService)
		{
			client.BaseAddress = new Uri("https://localhost:5001/api/");
			_client = client;
			_identityService = identityService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto,string? returnUrl)
		{
			var result = await _identityService.SignIn(loginDto);
			if (result == true)
			{
				if (returnUrl != null)
				{
					return Redirect(returnUrl);
				}
				return RedirectToAction("Index", "Default");
			}



			ModelState.AddModelError("", "Username or Password is wrong!");
			return View();
		}
	}
}
