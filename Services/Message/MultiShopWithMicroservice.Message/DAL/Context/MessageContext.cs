using Microsoft.EntityFrameworkCore;
using MultiShopWithMicroservice.Message.DAL.Entities;

namespace MultiShopWithMicroservice.Message.DAL.Context
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {

        }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
