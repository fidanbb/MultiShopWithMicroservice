using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService:IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync("productimages", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimages?id=" + id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>("productimages");
        }

        public async Task<UpdateProductImageDto> GetByIdProductImageAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateProductImageDto>("productimages/" + id);

        }

        public async Task<List<ResultProductImageDto>> GetImagesByProductId(string id)
        {
            var response = await _httpClient.GetAsync("productimages/GetImagesByProductID/" + id);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
                return value;
            }
            return null;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync("productimages", updateProductImageDto);
        }
    }
}
