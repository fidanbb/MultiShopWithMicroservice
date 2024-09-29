using MultiShopWithMicroservice.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
