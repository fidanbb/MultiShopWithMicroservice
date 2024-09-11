using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.IdentityDtos;
using MultiShopWithMicroservice.WebUI.Models;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json; 

namespace MultiShopWithMicroservice.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly HttpClient _client;
		private readonly ILoginService _loginService;
		public LoginController(HttpClient client, ILoginService loginService)
		{
			client.BaseAddress = new Uri("https://localhost:5001/api/");
			_client = client;
			_loginService = loginService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var result = await _client.PostAsJsonAsync("logins", loginDto);

			if (result.IsSuccessStatusCode)
			{
				//var id = _loginService.GetUserId;

				var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true,
				});


				if (tokenModel != null)
				{
					JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims=token.Claims.ToList();

					if (tokenModel.Token != null)
					{
						claims.Add(new Claim("multishoptoken", tokenModel.Token));

						var claimsIdentity=new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

						var authProps = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.ExpireDate,
							IsPersistent = true,
						};

						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
						return RedirectToAction("Index", "Default");
					}
				}
				return View();
			}

			ModelState.AddModelError("", "Username or Password is wrong!");
			return View();
		}
	}
}
