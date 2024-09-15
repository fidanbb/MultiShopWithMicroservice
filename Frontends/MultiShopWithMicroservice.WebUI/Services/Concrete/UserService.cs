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

		public async Task<UserDetailViewModel> GetUserInfo()
		{
			return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/GetUserInfo");
		}
	}
}
