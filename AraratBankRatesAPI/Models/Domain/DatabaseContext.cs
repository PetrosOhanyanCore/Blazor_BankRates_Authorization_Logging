using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AraratBankRatesAPI.Models.Domain

{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<TokenInfo> TokenInfo { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Exchange>(e =>
            {
                e.HasKey(l => new { l.Id });
            });

            builder.Entity<Exchange>(e =>
            {
                e.HasData(new[]
                {
                new Exchange() { Id = 1, ExchangeCode="001",ExchangeType="USD" },
                new Exchange() { Id = 2, ExchangeCode="049", ExchangeType="EUR"},
                new Exchange() { Id = 3, ExchangeCode="058", ExchangeType="RUR"},
                new Exchange() { Id = 4, ExchangeCode="002", ExchangeType="AMD"},
                });
            });


            builder.Entity<Transaction>(e
                => e.HasOne(t => t.ApplicationUser)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.UserId));

            base.OnModelCreating(builder);
        }


    }
}
