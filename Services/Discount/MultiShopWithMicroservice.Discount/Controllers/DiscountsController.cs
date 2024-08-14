using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Discount.Dtos;
using MultiShopWithMicroservice.Discount.Services;

namespace MultiShopWithMicroservice.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            return Ok(await _discountService.GetAllDiscountCouponsAsync());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            return Ok(await _discountService.GetByIdDiscountCouponAsync(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);

            return Ok("Coupon created successfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);

            return Ok("Coupon deleted successfully");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);

            return Ok("Coupon updated successfully");
        }
    }
}
