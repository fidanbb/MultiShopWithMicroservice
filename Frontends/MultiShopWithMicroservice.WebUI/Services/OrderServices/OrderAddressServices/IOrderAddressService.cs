﻿using MultiShopWithMicroservice.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        
        //Task<List<ResultAboutDto>> GetAboutAllAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        //Task DeleteAboutAsync(string id);
        //Task<ResultAboutGetByIdDto> GetByIdAboutAsync(string id); 
    }
}
