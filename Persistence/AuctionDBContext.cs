using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;

namespace ProjectApp.Persistence
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions<AuctionDBContext> options) : base(options){ }

        public DbSet<BidDB> BidDBs { get; set; }
        public DbSet<AuctionDB> AuctionDBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                AuctionDB adb = new AuctionDB
                {
                    AuctionID = -1,
                    Title = "Test vas",
                    Description = "Vas från 1800-talet",
                    Seller = "idali2@kth.se",
                    AskPrice = 200,
                    CreateDate = DateTime.Now,
                    EndTime = DateTime.MaxValue

                };
                modelBuilder.Entity<AuctionDB>().HasData(adb);

                BidDB bid1 = new BidDB
                {
                    BidID = -1,
                    Bidder = "sofia@kth.se",
                    Amount = 250,
                    BidDate = DateTime.Now,
                    AuctionID = -1
                };
                modelBuilder.Entity<BidDB>().HasData(bid1);


        }
    }
}
