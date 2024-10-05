using MultiShopWithMicroservice.DtoLayer.IdentityDtos;
using MultiShopWithMicroservice.WebUI.Models;

namespace MultiShopWithMicroservice.WebUI.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDetailViewModel> GetUserInfo();
        Task<List<ResultUserDto>> GetAllUsers();
    }
}
