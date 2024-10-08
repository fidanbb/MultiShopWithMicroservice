﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Cargo.BusinessLayer.Abstract;
using MultiShopWithMicroservice.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShopWithMicroservice.Cargo.EntityLayer.Concrete;

namespace MultiShopWithMicroservice.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(ICargoOperationService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoOperationList()
        {
            var values = await _cargoOperationService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationById(int id)
        {
            var value = await _cargoOperationService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var cargoOperation = _mapper.Map<CargoOperation>(createCargoOperationDto);
            await _cargoOperationService.TInsertAsync(cargoOperation);
            return Ok("Cargo Operation successfully created.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCargoOperation(int id)
        {
            await _cargoOperationService.TDeleteAsync(id);
            return Ok("Cargo Operation successfully deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var cargoOperation = _mapper.Map<CargoOperation>(updateCargoOperationDto);
            await _cargoOperationService.TUpdateAsync(cargoOperation);
            return Ok("Cargo Operation successfully updated.");
        }
    }
}
