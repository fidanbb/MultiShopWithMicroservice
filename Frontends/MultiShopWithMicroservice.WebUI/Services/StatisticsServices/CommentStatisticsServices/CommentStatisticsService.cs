namespace MultiShopWithMicroservice.WebUI.Services.StatisticsServices.CommentStatisticsServices
{
    public class CommentStatisticsService:ICommentStatisticsService
    {
        private readonly HttpClient _client;

        public CommentStatisticsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> GetActiveCommentCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("comments/GetActiveCommentCount");
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("comments/GetPassiveCommentCount");
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("comments/GetTotalCommentCount");
        }
    }
}
