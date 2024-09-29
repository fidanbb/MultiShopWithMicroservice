using Dapper;
using MultiShopWithMicroservice.Discount.Context;
using MultiShopWithMicroservice.Discount.Dtos;
using MultiShopWithMicroservice.Discount.Entities;

namespace MultiShopWithMicroservice.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "Delete from Coupons where CouponId=@couponId";
        
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            string query = "Select * from Coupons";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultDiscountCouponDto>(query);

                return values.ToList();

            }


        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
        {
            string query = "Select * from Coupons where CouponId=@couponId";

            var parametrs=new DynamicParameters();  
            parametrs.Add("@couponId", couponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parametrs);

                return value;

            }
        }

        public async Task<ResultDiscountCouponDto> GetCodeDetailByCouponCodeAsync(string code)
        {
            string query = "Select * from Coupons where Code=@code";

            var parametrs = new DynamicParameters();
            parametrs.Add("@code", code);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parametrs);

                return value;

            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
