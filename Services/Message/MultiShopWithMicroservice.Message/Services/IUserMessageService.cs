﻿using MultiShopWithMicroservice.Message.Dtos;

namespace MultiShopWithMicroservice.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        Task<int> GetTotalMessageCount();

        Task<int> GetTotalMessageCountByRecieverId(string id);
        Task<int> GetMessageCountByReceiverIdAsync(string id);
    }
}
