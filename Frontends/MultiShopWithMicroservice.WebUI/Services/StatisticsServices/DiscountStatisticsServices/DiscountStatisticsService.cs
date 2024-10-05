namespace MultiShopWithMicroservice.WebUI.Services.StatisticsServices.DiscountStatisticsServices
{
    public class DiscountStatisticsService:IDiscountStatisticsService
    {
        private readonly HttpClient _httpClient;

        public DiscountStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("discounts/GetDiscountCouponCount");
        }
    }
}
