using ProjectApp.Core;

namespace ProjectApp.ViewModels
{
    public class AuctionVM
    {
        public int AuctionID { get; set; }
        public string Title { get; set; }
        public string Seller { get; set; }
        public double AskPrice { get; set; }
        public DateTime CreateDate { get; set;  }
        public bool isClosed { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                AuctionID = auction.AuctionID,
                Title = auction.Title,
                Seller = auction.Seller,
                AskPrice = auction.AskPrice,
                CreateDate = auction.CreateDate
            };

        }
    }
}
