using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Accounts.Data;

namespace Accounts.Store
{
    public class AccountsContext : DbContext
    {
        public AccountsContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .LogTo( m => Console.WriteLine($"---\n{m}\n---"), LogLevel.Information  )
                //.UseLazyLoadingProxies()
                .UseSqlServer(
                @"data source=(LocalDb)\MSSQLLocalDB;" +
                @"initial catalog=Accounts2023T2;" +
                @"integrated security=True"
            );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Organization>()
                .Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<User>()
                .Property(e => e.UserName)
                .HasMaxLength(16)
                .IsRequired();

            builder.Entity<User>()
                .Property(e => e.Password)
                .HasMaxLength(32);        }

        public DbSet<Organization> Organizations { get; set; }
    }
}