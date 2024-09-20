using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService:IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ChangeIsReadAsync(string id)
        {
            var response = await _httpClient.GetAsync("contacts/ChangeIsRead/" + id);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {

                return true;
            }
            return false;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("contacts", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contacts?id=" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("contacts");
        }

        public async Task<UpdateContactDto> GetByIdContactAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateContactDto>("contacts/" + id);

        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync("contacts", updateContactDto);
        }
    }
}
