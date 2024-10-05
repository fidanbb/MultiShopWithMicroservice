using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.WebUI.Services.CommentServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.CatalogStatisticsServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.CommentStatisticsServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.DiscountStatisticsServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.MessageStatisticsServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.UserStatisticsServices;


namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticsController : Controller
    {
        private readonly ICatalogStatisticsService _catalogStatisticsService;
        private readonly IUserStatisticsService _userStatisticsService;
        private readonly ICommentStatisticsService _commentService;
        private readonly IDiscountStatisticsService _discountStatisticService;
        private readonly IMessageStatisticsService _messageStatisticService;

        public StatisticsController(ICatalogStatisticsService catalogStatisticsService, 
            IUserStatisticsService userStatisticsService, ICommentStatisticsService commentService, 
            IDiscountStatisticsService discountStatisticService, IMessageStatisticsService messageStatisticService)
        {
            _catalogStatisticsService = catalogStatisticsService;
            _userStatisticsService = userStatisticsService;
            _commentService = commentService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.brandCount = await _catalogStatisticsService.GetBrandCountAsync();
            ViewBag.categoryCount = await _catalogStatisticsService.GetCategoryCountAsync();
            ViewBag.getMaxPriceProductName = await _catalogStatisticsService.GetMostExpensiveProductName();
            ViewBag.getMinPriceProductName = await _catalogStatisticsService.GetCheapestProductName();
            //ViewBag.avgProductPrice= await _catalogStatisticsService.GetAvgProductPriceAsync();
            ViewBag.productCount = await _catalogStatisticsService.GetProductCountAsync();
            ViewBag.userCount = await _userStatisticsService.GetUserCountAsync();
            ViewBag.totalCommentCount = await _commentService.GetTotalCommentCountAsync();
            ViewBag.activeCommentCount = await _commentService.GetActiveCommentCountAsync();
            ViewBag.passiveCommentCount = await _commentService.GetPassiveCommentCountAsync();
            ViewBag.discountCouponCount = await _discountStatisticService.GetDiscountCouponCountAsync();
            ViewBag.messageCount = await _messageStatisticService.GetTotalMessageCountAsync();
            return View();
        }
    }
}
