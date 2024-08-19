using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Cargo.BusinessLayer.Abstract;
using MultiShopWithMicroservice.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShopWithMicroservice.Cargo.EntityLayer.Concrete;

namespace MultiShopWithMicroservice.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailsController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoDetailList()
        {
            var values = await _cargoDetailService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailById(int id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var cargoDetail = _mapper.Map<CargoDetail>(createCargoDetailDto);
            await _cargoDetailService.TInsertAsync(cargoDetail);
            return Ok("Cargo Detail successfully created.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCargoDetail(int id)
        {
            await _cargoDetailService.TDeleteAsync(id);
            return Ok("Cargo Detail successfully deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var cargoDetail = _mapper.Map<CargoDetail>(updateCargoDetailDto);
            await _cargoDetailService.TUpdateAsync(cargoDetail);
            return Ok("Cargo Detail successfully updated.");
        }
    }
}
