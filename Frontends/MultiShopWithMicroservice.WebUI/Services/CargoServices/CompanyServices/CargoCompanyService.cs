using MultiShopWithMicroservice.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CargoServices.CompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync("CargoCompanies", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("CargoCompanies?id=" + id);
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateCargoCompanyDto>("CargoCompanies/" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetCargoCompanyAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCargoCompanyDto>>("CargoCompanies");
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync("CargoCompanies", updateCargoCompanyDto);
        }
    }
}
