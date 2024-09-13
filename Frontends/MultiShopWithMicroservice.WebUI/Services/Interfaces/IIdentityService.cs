using MultiShopWithMicroservice.DtoLayer.IdentityDtos;

namespace MultiShopWithMicroservice.WebUI.Services.Interfaces
{
	public interface IIdentityService
	{
		Task<bool> SignIn(LoginDto loginDto);
	}
}
