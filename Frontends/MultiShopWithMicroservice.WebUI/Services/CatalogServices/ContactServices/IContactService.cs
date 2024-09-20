using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<UpdateContactDto> GetByIdContactAsync(string id);

        Task<bool> ChangeIsReadAsync(string id);
       
    }
}
