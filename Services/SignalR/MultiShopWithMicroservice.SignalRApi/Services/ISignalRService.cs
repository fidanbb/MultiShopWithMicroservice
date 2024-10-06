namespace MultiShopWithMicroservice.SignalRApi.Services
{
    public interface ISignalRService
    {

        Task<int> GetTotalCommentCountAsync();
    }
}
