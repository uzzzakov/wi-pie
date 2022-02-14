using Microsoft.EntityFrameworkCore;

namespace Khinkali.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> admins { get; set; }
        public DbSet<Pie> pies { get; set; }
        public DbSet<Khinkalis> khinkali { get; set; }
        public DbSet<Drink> drinks { get; set; }
        public DbSet<Order> orders { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
