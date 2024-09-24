﻿using MultiShopWithMicroservice.DtoLayer.BasketDtos;

namespace MultiShopWithMicroservice.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync();
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync();

        Task AddBasketItemAsync(BasketItemDto basketItemDto);

        Task<bool> RemoveBasketItemAsync(string productId);
    }
}
