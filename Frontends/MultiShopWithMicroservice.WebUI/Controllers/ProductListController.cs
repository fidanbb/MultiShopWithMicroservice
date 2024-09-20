using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class ProductListController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(string? id)
        {
            ViewBag.directory1 = "Home";
            ViewBag.directory2 = "Products";
            ViewBag.directory3 = "Product List";
            ViewBag.categoryId = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.directory1 = "Home";
            ViewBag.directory2 = "Products";
            ViewBag.directory3 = "Product Detail";
            ViewBag.productId = id;
            return View();
        }

        public async Task<bool> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.CreatedDate = DateTime.Now;
            createCommentDto.Status = false;
            createCommentDto.ImageUrl = "https://t4.ftcdn.net/jpg/02/15/84/43/360_F_215844325_ttX9YiIIyeaR7Ne6EaLLjMAmy4GvPC69.jpg";
			
			var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7075/api/Comments", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return true;

            }

            return false;
            
        }
    }
}
