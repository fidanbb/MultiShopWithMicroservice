namespace MultiShopWithMicroservice.WebUI.Services.StatisticsServices.UserStatisticsServices
{
    public class UserStatisticsService:IUserStatisticsService
    {
        private readonly HttpClient _client;

        public UserStatisticsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> GetUserCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("/api/Statistics/GetUserCount");
        }
    }
}
