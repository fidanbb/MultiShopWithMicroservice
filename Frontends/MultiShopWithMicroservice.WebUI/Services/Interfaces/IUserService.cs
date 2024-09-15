using MultiShopWithMicroservice.WebUI.Models;

namespace MultiShopWithMicroservice.WebUI.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDetailViewModel> GetUserInfo();
	}
}
