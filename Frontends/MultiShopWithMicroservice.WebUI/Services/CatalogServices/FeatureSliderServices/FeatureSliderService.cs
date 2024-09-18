using MultiShopWithMicroservice.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService:IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync("featuresliders", createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featuresliders?id=" + id);
        }

      

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDto>>("featuresliders");
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateFeatureSliderDto>("featuresliders/" + id);

        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync("featuresliders", updateFeatureSliderDto);
        }
    }
}
