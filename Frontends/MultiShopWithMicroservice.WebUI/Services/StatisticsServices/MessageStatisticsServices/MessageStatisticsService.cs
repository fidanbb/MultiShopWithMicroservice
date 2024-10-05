namespace MultiShopWithMicroservice.WebUI.Services.StatisticsServices.MessageStatisticsServices
{
    public class MessageStatisticsService:IMessageStatisticsService
    {
        private readonly HttpClient _client;

        public MessageStatisticsService(HttpClient client)
        {
            _client = client;
        }
        public async Task<int> GetTotalMessageCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("UserMessageStatistics/GetTotalMessageCount");
        }

    }
}
