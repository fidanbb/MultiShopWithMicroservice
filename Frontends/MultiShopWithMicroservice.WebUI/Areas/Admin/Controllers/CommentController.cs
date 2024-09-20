using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CommentDtos;
using MultiShopWithMicroservice.WebUI.ResultMessage;
using MultiShopWithMicroservice.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;
using X.PagedList.Extensions;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            CommentViewbagList();
            var values=await _commentService.GetAllCommentsAsync();

            int pageSize = 5;
            var pagedValues = values.ToPagedList(page, pageSize);
            int pagedCount = (pageSize * (page - 1));
            ViewBag.PageSize = pagedCount;

            return View(pagedValues);
        }

        public async Task<IActionResult> GetCommentsByProductId(string id)
        {
            CommentViewbagList();

            var values=await _commentService.GetCommentsByProductIdAsync(id);

            return View(values);
        }


        public async Task<IActionResult> ChangeStatus(int id)
        {
            var value=await _commentService.ChangeStatusAsync(id);

         
            return RedirectToAction("Index", "Comment", new { Area = "Admin" });
         
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            CommentViewbagList();

            var value = await _commentService.GetCommentByIdAsync(id);

           
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            await _commentService.UpdateCommentAsync(updateCommentDto);
           
             return RedirectToAction("Index", "Comment", new { area = "Admin" });
            
        }

        void CommentViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comments";
            ViewBag.v3 = "CommentList";
            ViewBag.v0 = "Comment Operations";
        }
    }
}
