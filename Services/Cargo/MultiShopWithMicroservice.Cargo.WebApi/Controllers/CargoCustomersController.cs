using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Cargo.BusinessLayer.Abstract;
using MultiShopWithMicroservice.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShopWithMicroservice.Cargo.EntityLayer.Concrete;

namespace MultiShopWithMicroservice.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCustomerList()
        {
            var values = await _cargoCustomerService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomerById(int id)
        {
            var value = await _cargoCustomerService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(createCargoCustomerDto);
            await _cargoCustomerService.TInsertAsync(cargoCustomer);
            return Ok("Cargo Customer successfully added");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCargoCustomer(int id)
        {
            await _cargoCustomerService.TDeleteAsync(id);
            return Ok("Cargo Customer successfully deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(updateCargoCustomerDto);
            await _cargoCustomerService.TUpdateAsync(cargoCustomer);
            return Ok("Cargo Customer successfully updated.");
        }

        [HttpGet("GetCargoCustomerByUserCustomerID")]
        public async Task<IActionResult> GetCargoCustomerByUserCustomerID(string userCustomerID)
        {
            var value = await _cargoCustomerService.TGetCargoCustomerByUserCustomerID(userCustomerID);
            return Ok(value);
        }
    }
}
