using MultiShopWithMicroservice.DtoLayer.OrderDtos.OrderDetailDtos;

namespace MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<List<ResultOrderDetailDto>> GetOrderDetailByOrderingIdAsync(int id);
    }
}
