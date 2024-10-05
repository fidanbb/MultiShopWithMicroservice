﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Catalog.Services.StatisticsServices;

namespace MultiShopWithMicroservice.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCountAsync()
        {
            return Ok(await _statisticService.GetBrandCountAsync());
        }
        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCountAsync()
        {
            return Ok(await _statisticService.GetProductCountAsync());
        }
        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCountAsync()
        {
            return Ok(await _statisticService.GetCategoryCountAsync());
        }
        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPriceAsync()
        {
            return Ok(await _statisticService.GetProductAvgPriceAsync());
        }
        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductNameAsync()
        {
            return Ok(await _statisticService.GetMaxPriceProductNameAsync());
        }
        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductNameAsync()
        {
            return Ok(await _statisticService.GetMinPriceProductNameAsync());
        }
    }
}
