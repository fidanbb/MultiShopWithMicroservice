using MultiShopWithMicroservice.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService:ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync("specialoffers", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialoffers?id=" + id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDto>>("specialoffers");
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateSpecialOfferDto>("specialoffers/" + id);

        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync("specialoffers", updateSpecialOfferDto);
        }
    }
}
