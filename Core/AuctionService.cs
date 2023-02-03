using ProjectApp.Core.Interfaces;

namespace ProjectApp.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersistence;

        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }



        public void Add(Auction auction)
        {
            if (auction == null || auction.AuctionID != 0) throw new InvalidDataException();
            _auctionPersistence.Add(auction);
        }

        public List<Auction> GetAuctions(string username)
        {
            return _auctionPersistence.GetAuctions(username);
        }


        public List<Auction> GetAll()
        {
            return _auctionPersistence.GetAll();
        }

        public List<Auction> GetAllByUsername(string username)
        {
            return _auctionPersistence.GetAllByUsername(username);
        }

        public Auction GetByID(int id)
        {
            return _auctionPersistence.GetByID(id);
        }


        public void EditDescription(Auction auction)
        {
            _auctionPersistence.EditDescription(auction);
        }

        public Auction GetDescription(int id)
        {
            return _auctionPersistence.GetDescription(id);
        }

        void IAuctionService.AddBid(Bid bid, int id)
        {
            if (bid == null) throw new InvalidDataException();
            _auctionPersistence.AddBid(bid, id);
        }

        public List<Auction> GetWins(string username)
        {
            return _auctionPersistence.GetWins(username);
        }

        public bool CanBidExecute(Bid bid, List<Bid> bids)
        {
            return _auctionPersistence.CanBidExecute(bid, bids);
        }
    }
}
