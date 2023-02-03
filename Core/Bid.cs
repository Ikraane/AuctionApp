namespace ProjectApp.Core
{
    public class Bid
    {
        public int BidID { get; set; }
        public string Bidder { get; set; }
        public int Amount { get; set; }
        public DateTime BidDate { get; set; } 

        public Bid(string bidder, int amount, DateTime bidDate)
        {
            Bidder = bidder;
            Amount = amount;
            BidDate = bidDate;
        }

        public Bid()
        {

        }

        public override string? ToString()
        {
            return $"{BidID}: Bidder: {Bidder} - Amount: {Amount} - Date: {BidDate}";
        }

    }
}
