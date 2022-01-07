using Microsoft.EntityFrameworkCore;

namespace Khinkali.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> admins { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
