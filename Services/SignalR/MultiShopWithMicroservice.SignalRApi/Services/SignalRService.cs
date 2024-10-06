namespace MultiShopWithMicroservice.SignalRApi.Services
{
    public class SignalRService:ISignalRService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<int> GetTotalCommentCountAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7075/api/CommentStatistics/GetCommentCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadFromJsonAsync<int>();
                return jsonData;
            }
            else
            {
                return 0;
            }
        }
    }
}
