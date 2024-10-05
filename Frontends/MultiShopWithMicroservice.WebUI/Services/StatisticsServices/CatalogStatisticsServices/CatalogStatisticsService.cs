using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace MultiShopWithMicroservice.WebUI.Services.StatisticsServices.CatalogStatisticsServices
{
    public class CatalogStatisticsService: ICatalogStatisticsService
    {
        private readonly HttpClient _client;

        public CatalogStatisticsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<decimal> GetAvgProductPriceAsync()
        {
            return await _client.GetFromJsonAsync<decimal>("statistics/GetProductAvgPrice");
        }

        public async Task<long> GetBrandCountAsync()
        {
            return await _client.GetFromJsonAsync<long>("statistics/GetBrandCount");
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _client.GetFromJsonAsync<long>("statistics/GetCategoryCount");
        }

        public async Task<string> GetCheapestProductName()
        {
            return await _client.GetStringAsync("statistics/GetMinPriceProductName");
        }

        public async Task<string> GetMostExpensiveProductName()
        {
            return await _client.GetStringAsync("statistics/GetMaxPriceProductName");
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _client.GetFromJsonAsync<long>("statistics/GetProductCount");
        }

    }
}
