namespace MultiShopWithMicroservice.WebUI.Services.StatisticsServices.CatalogStatisticsServices
{
    public interface ICatalogStatisticsService
    {
        Task<long> GetProductCountAsync();
        Task<long> GetCategoryCountAsync();
        Task<long> GetBrandCountAsync();
        Task<decimal> GetAvgProductPriceAsync();
        Task<string> GetMostExpensiveProductName();
        Task<string> GetCheapestProductName();
    }
}
