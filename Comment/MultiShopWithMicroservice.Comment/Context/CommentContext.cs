using Microsoft.EntityFrameworkCore;
using MultiShopWithMicroservice.Comment.Entities;

namespace MultiShopWithMicroservice.Comment.Context
{
    public class CommentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=MultiShopCommentDb;User=sa;Password=123456aA*;TrustServerCertificate=True");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
