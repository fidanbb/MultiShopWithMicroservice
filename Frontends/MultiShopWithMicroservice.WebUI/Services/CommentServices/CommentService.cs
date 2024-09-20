using MultiShopWithMicroservice.DtoLayer.CommentDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CommentServices
{
    public class CommentService:ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ChangeStatusAsync(int id)
        {
            var response = await _httpClient.GetAsync("comments/ChangeStatus/" + id);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                
                return true;
            }
            return false;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync("comments", createCommentDto);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _httpClient.DeleteAsync("comments?id=" + id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("comments");
        }

        public async Task<UpdateCommentDto> GetCommentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateCommentDto>("comments/" + id);

        }

        public async Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string id)
        {
            var response = await _httpClient.GetAsync("comments/CommentListByProductId?id=" + id);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
                return value;
            }
            return null;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync("comments", updateCommentDto);
        }
    }
}
