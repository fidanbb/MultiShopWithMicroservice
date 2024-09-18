using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<UpdateProductImageDto> GetByIdProductImageAsync(string id);

        Task<List<ResultProductImageDto>> GetImagesByProductId(string id);
    }
}
