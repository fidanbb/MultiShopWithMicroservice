using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService:IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _client.PostAsJsonAsync("products", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _client.DeleteAsync("products?id=" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultProductDto>>("products");
        }

        public async Task<UpdateProductDto> GetProductByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateProductDto>("products/" + id);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsByCategoryIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("products/ProductListWithCategoryByCategoryId?id=" + id);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _client.PutAsJsonAsync("products", updateProductDto);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("products/ProductListWithCategory");
        }
    }
}
