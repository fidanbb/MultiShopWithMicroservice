using MultiShopWithMicroservice.DtoLayer.BasketDtos;
using MultiShopWithMicroservice.WebUI.Services.DiscountServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IDiscountService _discountService;

        public BasketService(HttpClient httpClient, IDiscountService discountService)
        {
            _httpClient = httpClient;
            _discountService = discountService;
        }
        public async Task AddBasketItemAsync(BasketItemDto basketItemDto)
        {
            var values = await GetBasketAsync();
            

            if (values != null)
            {
                var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);

                if (existingItem == null)
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    existingItem.Quantity += basketItemDto.Quantity;
                }
            }
        
            await SaveBasketAsync(values);
        }
        public async Task<bool> ApplyDiscountAsync(string discountCode)
        {
            await CancelApplyDiscountAsync();
            var basket = await GetBasketAsync();

            var hasDiscount = await _discountService.GetDiscountCode(discountCode);
            if (hasDiscount == null)
            {
                return false;
            }
            basket.DiscountRate = hasDiscount.Rate;
            basket.DiscountCode = hasDiscount.Code;
            await SaveBasketAsync(basket);
            return true;
        }

        public async Task<bool> CancelApplyDiscountAsync()
        {
            var basket = await GetBasketAsync();
            basket.DiscountCode = "-";
            basket.DiscountRate = 0;
            await SaveBasketAsync(basket);
            return true;
        }
        public async Task DeleteBasketAsync()
        {
            await _httpClient.DeleteAsync("baskets");
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
            var response = await _httpClient.GetAsync("baskets");

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                var value = await response.Content.ReadFromJsonAsync<BasketTotalDto>();
                return value;
            }

            else
            {
               var values = new BasketTotalDto
                {
                    UserId = "",
                    DiscountCode = "-",
                    DiscountRate = 0,
                    BasketItems = new List<BasketItemDto>()
                };
                await SaveBasketAsync(values);
                return values;
            }
           
            //return await _httpClient.GetFromJsonAsync<BasketTotalDto>("baskets");
        }

        public async Task<bool> RemoveBasketItemAsync(string productId)
        {
           var values=await GetBasketAsync();

            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            //if (deletedItem.Quantity > 1)
            //{
            //    deletedItem.Quantity -= 1;
            //    await SaveBasketAsync(values);
            //}

            if (deletedItem != null)
            {
                values.BasketItems.Remove(deletedItem);
                await SaveBasketAsync(values);
                return true;
            }
            return false;
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        { 
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}
