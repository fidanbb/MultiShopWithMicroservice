using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.IdentityServer.Dtos;
using MultiShopWithMicroservice.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShopWithMicroservice.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]

        public async Task<IActionResult>UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName=userRegisterDto.Username,
                Email=userRegisterDto.Email,
                Name=userRegisterDto.Name,
                Surname=userRegisterDto.Surname,
            };

            var result=await _userManager.CreateAsync(values,userRegisterDto.Password);

            if (result.Succeeded)
            {
                return Ok("User added successfully");
            }

            else
            {
                return Ok("Something happened, please try again!");

            }

        }
    }
}
