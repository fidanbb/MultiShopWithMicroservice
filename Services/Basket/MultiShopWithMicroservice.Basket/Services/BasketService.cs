using MultiShopWithMicroservice.Basket.Dtos;
using MultiShopWithMicroservice.Basket.Settings;
using System.Text.Json;

namespace MultiShopWithMicroservice.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }
        public async Task DeleteBasketAsync(string userId)
        {
          await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {
            var existBasket=await _redisService.GetDb().StringGetAsync(userId);

            if(existBasket.IsNull)
            {
                return null;
            }

            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);

        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserID, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
