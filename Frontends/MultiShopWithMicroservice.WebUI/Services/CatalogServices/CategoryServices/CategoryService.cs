using MultiShopWithMicroservice.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync("categories",createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories?id=" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateCategoryDto>("categories/" + id);

        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("categories", updateCategoryDto);
        }
    }
}
