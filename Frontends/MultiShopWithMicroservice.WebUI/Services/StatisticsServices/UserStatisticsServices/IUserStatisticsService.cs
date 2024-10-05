namespace MultiShopWithMicroservice.WebUI.Services.StatisticsServices.UserStatisticsServices
{
    public interface IUserStatisticsService
    {
        Task<int> GetUserCountAsync();
    }
}
