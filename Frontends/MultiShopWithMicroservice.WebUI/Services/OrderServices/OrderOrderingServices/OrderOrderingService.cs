using MultiShopWithMicroservice.DtoLayer.DiscountDtos;
using MultiShopWithMicroservice.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService:IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {

            return await _httpClient.GetFromJsonAsync<List<ResultOrderingByUserIdDto>>("Orderings/GetOrderingByUserId/" + id);

           
        }
    }
}
