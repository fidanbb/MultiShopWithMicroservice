using MultiShopWithMicroservice.DtoLayer.IdentityDtos;
using MultiShopWithMicroservice.WebUI.Models;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;

namespace MultiShopWithMicroservice.WebUI.Services.Concrete
{
	public class UserService:IUserService
	{
		private readonly HttpClient _httpClient;

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

        public async Task<List<ResultUserDto>> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultUserDto>>("/api/users/GetAllUsers");
        }

        public async Task<UserDetailViewModel> GetUserInfo()
		{
			return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/GetUserInfo");
		}
	}
}
