using MultiShopWithMicroservice.DtoLayer.CommentDtos;

namespace MultiShopWithMicroservice.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentsAsync();

        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);

        Task DeleteCommentAsync(int id);

        Task<UpdateCommentDto> GetCommentByIdAsync(int id);
        Task<bool> ChangeStatusAsync(int id);

        Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string id);

    }
}
