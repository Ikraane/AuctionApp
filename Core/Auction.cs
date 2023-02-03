using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Core
{
    public class Auction
    {
        public int AuctionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Seller { get; set; }
        public double AskPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndTime { get; set; }
        private List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;


        public Auction(int auctionID, string description)
        {
            AuctionID =auctionID;
            Description = description;
        }

        public Auction()
        {

        }


        public void addBid(Bid bid)
        {
            if (bid.Amount > AskPrice || bid.Amount >= _bids.Max(Bid => Bid.Amount))
            {
                _bids.Add(bid);
            }

        }


    }
}
