using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShopWithMicroservice.Discount.Entities;
using System.Data;
using static Azure.Core.HttpHeader;

namespace MultiShopWithMicroservice.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-FV06R42;initial Catalog=MultiShopDiscountDB;integrated Security=true; TrustServerCertificate=true;");
        //}

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
