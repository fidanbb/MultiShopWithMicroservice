using AutoMapper;
using MultiShopWithMicroservice.Message.DAL.Entities;
using MultiShopWithMicroservice.Message.Dtos;

namespace MultiShopWithMicroservice.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultMessageDto, UserMessage>().ReverseMap();
            CreateMap<UpdateMessageDto, UserMessage>().ReverseMap();
            CreateMap<CreateMessageDto, UserMessage>().ReverseMap();
            CreateMap<GetByIdMessageDto, UserMessage>().ReverseMap();
            CreateMap<ResultInboxMessageDto, UserMessage>().ReverseMap();
            CreateMap<ResultSendboxMessageDto, UserMessage>().ReverseMap();
        }
    }
}
