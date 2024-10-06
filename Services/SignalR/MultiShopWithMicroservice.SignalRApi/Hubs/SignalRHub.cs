using Microsoft.AspNetCore.SignalR;
using MultiShopWithMicroservice.SignalRApi.Services;

namespace MultiShopWithMicroservice.SignalRApi.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ISignalRService _signalRService;

        public SignalRHub(ISignalRService signalRService)
        {
            _signalRService = signalRService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRService.GetTotalCommentCountAsync();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
           
        }
    }
}
