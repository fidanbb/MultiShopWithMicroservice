using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopWithMicroservice.Comment.Context;
using MultiShopWithMicroservice.Comment.Entities;

namespace MultiShopWithMicroservice.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var value = _commentContext.UserComments.ToList();
            return Ok(value);
        }

        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            return Ok(value);
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            _commentContext.UserComments.Update(value);
            _commentContext.SaveChanges();
            return Ok("Comment Status Updated successfully");
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Comment added successfully");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Comment deleted successfully");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Comment updated successfully");
        }

        [HttpGet("GetActiveCommentCount")]
        public async Task<IActionResult> GetActiveCommentCount()
        {
            int values = await _commentContext.UserComments.Where(x => x.Status == true).CountAsync();
            return Ok(values);
        }

        [HttpGet("GetPassiveCommentCount")]
        public async Task<IActionResult> GetPassiveCommentCount()
        {
            int values = await _commentContext.UserComments.Where(x => x.Status == false).CountAsync();
            return Ok(values);
        }

        [HttpGet("GetTotalCommentCount")]
        public async Task<IActionResult> GetTotalCommentCount()
        {
            int values = await _commentContext.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
