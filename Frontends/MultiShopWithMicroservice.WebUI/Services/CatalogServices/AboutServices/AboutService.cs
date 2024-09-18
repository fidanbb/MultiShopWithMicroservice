using MultiShopWithMicroservice.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService:IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync("abouts", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("abouts?id=" + id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateAboutDto>("abouts/" + id);

        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync("abouts", updateAboutDto);
        }
    }
}
