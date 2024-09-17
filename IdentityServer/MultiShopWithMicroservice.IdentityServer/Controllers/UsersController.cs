using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.IdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShopWithMicroservice.IdentityServer.Controllers
{
	[Authorize(LocalApi.PolicyName)]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public UsersController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet("GetUserInfo")]

		public async Task<IActionResult> GetUserInfo()
		{
			var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
			var user = await _userManager.FindByIdAsync(userClaim.Value);

			return Ok(new 
			{
				Id=user.Id,
				UserName=user.UserName,
				Email=user.Email,
				Name = user.Name,
				Surname = user.Surname,
			});
		}
	}
}
