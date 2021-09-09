using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Models;

namespace PayCoin.Server.Data
{
    public class PayCoinContext : DbContext
    {
        public PayCoinContext(DbContextOptions<PayCoinContext> options)
            : base(options)
        {
        }

        public DbSet<PayCoin.Server.Models.User> User { get; set; }
        public DbSet<PayCoin.Server.Models.Role> Role { get; set; }
        public DbSet<PayCoin.Server.Models.UserRole> UserRole { get; set; }

        public DbSet<PayCoin.Server.Models.Admin> Admin { get; set; }

        public DbSet<PayCoin.Server.Models.Community> Community { get; set; }

        public DbSet<PayCoin.Server.Models.Provider> Provider { get; set; }

        public DbSet<PayCoin.Server.Models.Designer> Designer { get; set; }

        public DbSet<PayCoin.Server.Models.Delivery> Delivery { get; set; }

        public DbSet<PayCoin.Server.Models.Category> Category { get; set; }

        public DbSet<PayCoin.Server.Models.ChildCategory> ChildCategory { get; set; }

        public DbSet<PayCoin.Server.Models.SmallCategory> SmallCategory { get; set; }

        public DbSet<PayCoin.Server.Models.CategoryProvider> CategoryProvider { get; set; }

        public DbSet<PayCoin.Server.Models.ChildCategoryProvider> ChildCategoryProvider { get; set; }

        public DbSet<PayCoin.Server.Models.Coupon> Coupon { get; set; }

        public DbSet<PayCoin.Server.Models.Shipping> Shipping { get; set; }

        public DbSet<PayCoin.Server.Models.Product> Product { get; set; }
    }
}
