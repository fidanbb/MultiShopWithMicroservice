using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();

        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(string id);

        Task<UpdateProductDto> GetProductByIdAsync(string id);

        Task CreateProductAsync(CreateProductDto createProductDto);
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsByCategoryIdAsync(string id);

    }
}
