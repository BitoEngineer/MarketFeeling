using AutoFixture;
using MarketFeeling.Infrastructure.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketFeeling.Infrastructure.Tests
{
    [TestClass]
    public class MarketFelingContextTests
    {
        private static MarketFeelingDbContext _dbContext;

        [ClassInitialize]
        public static void Initialize(TestContext ctx)
        {
            _dbContext = new MarketFeelingDbContext(new Utils.MarketFeelingsDbConfiguration
            {
                DatabaseConnectionString = "Server=tcp:marketfeelingdb.database.windows.net,1433;Initial Catalog=marketfeelingdb;Persist Security Info=False;User ID=MarketFeelingInfrastructure;Password=Fc#p}XLQ[ha{*Y3egJ.s5u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            });
        }

        [TestMethod]
        public async Task Insert_thenRead_thenDeleteNews()
        {
            var fixture = new Fixture();

            var randomNew = fixture.Build<New>().Without(x => x.Id).Create();
            var insertResult = _dbContext.News.Add(randomNew);

            await _dbContext.SaveChangesAsync();

            var insertedNew = _dbContext.News.FirstOrDefault(x => x.Id == insertResult.Entity.Id);
            Assert.IsNotNull(insertedNew);

            _dbContext.News.Remove(insertResult.Entity);

            await _dbContext.SaveChangesAsync();

            var deletedNew = _dbContext.News.FirstOrDefault(x => x.Id == insertResult.Entity.Id);
            Assert.IsNull(deletedNew);
        }
    }
}