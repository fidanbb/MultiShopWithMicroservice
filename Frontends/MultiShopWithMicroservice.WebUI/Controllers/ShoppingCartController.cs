using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.BasketDtos;
using MultiShopWithMicroservice.WebUI.Services.BasketServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }
        public IActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Home";
            ViewBag.Directory3 = "My Basket";
            return View();
        }
        //[HttpPost]
        public async Task<IActionResult> AddBasketItem(string id)
        {
            //var currentUserId = User.Claims.FirstOrDefault(x => x.Type == "sub");

            //if (currentUserId?.Value == null)
            //{
            //    return Json(false);
            //}

            var values = await _productService.GetProductByIdAsync(id);
            var items = new BasketItemDto
            {
                Price = values.ProductPrice,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl,
            };

            await _basketService.AddBasketItemAsync(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItemAsync(id);
            return RedirectToAction("Index");
        }
    }
}
