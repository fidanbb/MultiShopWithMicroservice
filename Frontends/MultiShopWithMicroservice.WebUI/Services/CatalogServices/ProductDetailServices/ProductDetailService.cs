using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService:IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync("productdetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetails?id=" + id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDetailDto>>("productdetails");
        }

        public async Task<UpdateProductDetailDto> GetProductDetailByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateProductDetailDto>("productdetails/" + id);

        }

        public async Task<ResultProductDetailDto> GetProductDetailByProductIdAsync(string id)
        {
            var response = await _httpClient.GetAsync("productDetails/GetProductDetailByProductId/" + id);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                var value = await response.Content.ReadFromJsonAsync<ResultProductDetailDto>();
                return value;
            }
            return null;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync("productdetails", updateProductDetailDto);
        }
    }
}
