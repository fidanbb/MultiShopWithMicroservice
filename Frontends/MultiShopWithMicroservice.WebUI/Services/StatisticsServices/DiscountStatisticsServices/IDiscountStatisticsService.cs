namespace MultiShopWithMicroservice.WebUI.Services.StatisticsServices.DiscountStatisticsServices
{
    public interface IDiscountStatisticsService
    {
        Task<int> GetDiscountCouponCountAsync();
    }
}
