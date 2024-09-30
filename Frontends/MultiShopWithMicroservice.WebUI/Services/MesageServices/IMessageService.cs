using MultiShopWithMicroservice.DtoLayer.MessageDtos;

namespace MultiShopWithMicroservice.WebUI.Services.MesageServices
{
    public interface IMessageService
    { 
        //Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);

        Task<int> GetTotalMessageCountByRecieverId(string id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int id);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}
