using AutoMapper;
using MongoDB.Driver;
using MultiShopWithMicroservice.Catalog.Dtos.ContactDtos;
using MultiShopWithMicroservice.Catalog.Entities;
using MultiShopWithMicroservice.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace MultiShopWithMicroservice.Catalog.Services.ContactServices
{
    public class ContactService:IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;
        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var values = await _contactCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(values);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, values);
        }

        public async Task ChangeIsReadAsync(string id)
        {
            var value = await _contactCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync();
            if (value.IsRead)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }

            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == id, value);

        }
    }
}
