using MultiShopWithMicroservice.DtoLayer.MessageDtos;

namespace MultiShopWithMicroservice.WebUI.Services.MesageServices
{
    public class MessageService:IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
           
            return await _httpClient.GetFromJsonAsync<List<ResultInboxMessageDto>>("UserMessage/GetMessageInbox?id=" + id);
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultSendboxMessageDto>>("UserMessage/GetMessageSendbox?id=" + id);

        }

        public async Task<int> GetTotalMessageCountByRecieverId(string id)
        {
            return await _httpClient.GetFromJsonAsync<int>("UserMessage/GetTotalMessageCountByRecieverId?id=" + id);
        }
    }
}
