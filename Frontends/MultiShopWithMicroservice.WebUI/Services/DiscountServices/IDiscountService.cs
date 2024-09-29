using MultiShopWithMicroservice.DtoLayer.DiscountDtos;

namespace MultiShopWithMicroservice.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
    }
}
