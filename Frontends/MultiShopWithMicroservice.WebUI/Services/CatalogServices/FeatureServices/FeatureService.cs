using MultiShopWithMicroservice.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService:IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeaturesDto)
        {
            await _httpClient.PostAsJsonAsync("features", createFeaturesDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("features?id=" + id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultFeatureDto>>("features");
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateFeatureDto>("features/" + id);

        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeaturesDto)
        {
            await _httpClient.PutAsJsonAsync("features", updateFeaturesDto);
        }
    }
}
