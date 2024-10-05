using MultiShopWithMicroservice.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService:ICargoCustomerService
    {
        private readonly HttpClient _client;

        public CargoCustomerService(HttpClient client)
        {
            _client = client;
        }
        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            await _client.PostAsJsonAsync("cargocustomers", createCustomerDto);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _client.DeleteAsync("cargocustomers?id=" + id);
        }

        public async Task<IList<ResultCustomerDto>> GetAllCustomersAsync()
        {
            return await _client.GetFromJsonAsync<IList<ResultCustomerDto>>("cargocustomers");
        }

        public async Task<UpdateCustomerDto> GetCustomerByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateCustomerDto>("cargocustomers/" + id);
        }

        public async Task<IList<ResultCustomerDto>> GetDetailsByUserIdAsync(string id)
        {
            var response = await _client.GetAsync("cargocustomers/GetCargoCustomerByUserCustomerID?id=" + id);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                var value = await response.Content.ReadFromJsonAsync<IList<ResultCustomerDto>>();
                return value;
            }
            return null;

            //return await _client.GetFromJsonAsync<IList<ResultCustomerDto>>("cargocustomers/GetCargoCustomerByUserCustomerID?id=" + id);

        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            await _client.PutAsJsonAsync("cargocustomers", updateCustomerDto);
        }
    }
}
