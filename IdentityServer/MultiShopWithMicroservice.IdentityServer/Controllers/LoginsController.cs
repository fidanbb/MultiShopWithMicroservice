using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.IdentityServer.Dtos;
using MultiShopWithMicroservice.IdentityServer.Models;
using MultiShopWithMicroservice.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.IdentityServer.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

		public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);

			if (result.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(userLoginDto.Username);
				var model = new GetCheckAppUserViewModel();
				model.UserName = userLoginDto.Username;
				model.Id = user.Id;
				model.Name = user.Name;
				model.Surname = user.Surname;
				var token = JwtTokenGenerator.GenerateToken(model);
				return Ok(token);
			}
			return BadRequest("Username or Password is wrong!");
		}
	}
}
