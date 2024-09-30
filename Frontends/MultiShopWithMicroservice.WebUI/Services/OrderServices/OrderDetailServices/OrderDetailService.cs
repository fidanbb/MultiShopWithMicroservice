using MultiShopWithMicroservice.DtoLayer.OrderDtos.OrderDetailDtos;

namespace MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderDetailServices
{
    public class OrderDetailService(HttpClient _client) : IOrderDetailService
    {
        public async Task<List<ResultOrderDetailDto>> GetOrderDetailByOrderingIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<List<ResultOrderDetailDto>>("orderDetails/getorderdetailbyorderingid/" + id);
        }
    }
}
