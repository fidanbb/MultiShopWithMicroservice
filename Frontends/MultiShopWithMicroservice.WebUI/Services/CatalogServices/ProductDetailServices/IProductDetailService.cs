using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<UpdateProductDetailDto> GetProductDetailByIdAsync(string id);
        Task<ResultProductDetailDto> GetProductDetailByProductIdAsync(string id);
    }
}
