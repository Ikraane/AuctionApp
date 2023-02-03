namespace ProjectApp.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAllByUsername(string username);

        List<Auction> GetAll();
        Auction GetByID(int id);
        void Add(Auction auction);

        void AddBid(Bid bid, int id);

        public void EditDescription(Auction auction);
        public Auction GetDescription(int id);

        public List<Auction> GetAuctions(string username);

        public List<Auction> GetWins(string username);

        public bool CanBidExecute(Bid bid, List<Bid> bids);

    }
}
