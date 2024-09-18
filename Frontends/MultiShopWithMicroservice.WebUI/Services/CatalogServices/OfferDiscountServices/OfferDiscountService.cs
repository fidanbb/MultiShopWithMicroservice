using MultiShopWithMicroservice.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService:IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync("offerdiscounts", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("offerdiscounts?id=" + id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("offerdiscounts");
        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateOfferDiscountDto>("offerdiscounts/" + id);

        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync("offerdiscounts", updateOfferDiscountDto);
        }
    }
}
