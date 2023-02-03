using ProjectApp.Core;
using Bid = ProjectApp.Core.Bid;

namespace ProjectApp.ViewModels
{
    public class BidVM
    {
        public int BidID { get; set; }
        public string Bidder { get; set; }
        public int Amount { get; set; }
        public DateTime BidDate { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                BidID = bid.BidID,
                Bidder = bid.Bidder,
                Amount = bid.Amount,
                BidDate = bid.BidDate
            };
        }
    }
}
