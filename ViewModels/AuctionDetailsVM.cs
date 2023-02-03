using ProjectApp.Core;

namespace ProjectApp.ViewModels
{
    public class AuctionDetailsVM
    {
        public int AuctionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Seller { get; set; }
        public double AskPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndTime { get; set; }
        public List<BidVM> BidVMs { get; set; } = new();

        public static AuctionDetailsVM FromAuction(Auction auction)
        {
            var detailsVM = new AuctionDetailsVM()
            {
                AuctionID = auction.AuctionID,
                Title = auction.Title,
                Description = auction.Description,
                Seller = auction.Seller,
                AskPrice = auction.AskPrice,
                CreateDate = auction.CreateDate,
                EndTime = auction.EndTime
            };
            foreach(var bid in auction.Bids)
            {
                detailsVM.BidVMs.Add(BidVM.FromBid(bid));
            }
            return detailsVM;
        }
    }
}
