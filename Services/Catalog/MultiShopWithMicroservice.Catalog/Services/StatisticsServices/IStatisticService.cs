namespace MultiShopWithMicroservice.Catalog.Services.StatisticsServices
{
    public interface IStatisticService
    {
        Task<long> GetProductCountAsync();
        Task<long> GetCategoryCountAsync();
        Task<long> GetBrandCountAsync();
        Task<decimal> GetProductAvgPriceAsync();
        Task<string> GetMaxPriceProductNameAsync();
        Task<string> GetMinPriceProductNameAsync();
    }
}
