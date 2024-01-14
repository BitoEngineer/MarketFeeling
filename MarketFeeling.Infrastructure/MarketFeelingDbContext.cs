using MarketFeeling.Infrastructure.Entities;
using MarketFeeling.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace MarketFeeling.Infrastructure
{
    public class MarketFeelingDbContext : DbContext
    {
        public DbSet<New> News { get; set; }

        private readonly MarketFeelingsDbConfiguration _config;

        public MarketFeelingDbContext(MarketFeelingsDbConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public MarketFeelingDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:marketfeelingdb.database.windows.net,1433;Initial Catalog=marketfeelingdb;Persist Security Info=False;User ID=MarketFeelingInfrastructure;Password=Fc#p}XLQ[ha{*Y3egJ.s5u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<New>()
                .HasKey(x => x.Id);
        }
    }
}
