using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Catalog.Dtos.ProductImageDtos;
using MultiShopWithMicroservice.Catalog.Services.ProductImageServices;

namespace MultiShopWithMicroservice.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]

        public async Task<IActionResult> ProductImageList()
        {
            return Ok(await _productImageService.GetAllProductImageAsync());
        }

        [HttpPost]

        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);

            return Ok("ProductImage added successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);

            return Ok("ProductImage deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            return Ok(await _productImageService.GetByIdProductImageAsync(id));
        }

        [HttpGet("GetProductImageByProductId/{id}")]
        public async Task<IActionResult> GetProductImageByProductId(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);

            return Ok("ProductImage updated successfully");
        }
    }
}
