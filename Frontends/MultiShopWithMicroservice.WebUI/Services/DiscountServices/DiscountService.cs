using MultiShopWithMicroservice.DtoLayer.DiscountDtos;

namespace MultiShopWithMicroservice.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            return await _httpClient.GetFromJsonAsync<GetDiscountCodeDetailByCode>("discounts/getdiscountcodedetailbycode?code=" + code);
        }
    }
}
