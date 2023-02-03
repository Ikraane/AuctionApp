using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.ViewModels;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using Bid = ProjectApp.Core.Bid;

namespace ProjectApp.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDBContext _dBContext;
        private IMapper _mapper;

        public AuctionSqlPersistence(AuctionDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public void Add(Auction auction)
        {
            AuctionDB adb = _mapper.Map<AuctionDB>(auction);
            _dBContext.AuctionDBs.Add(adb);
            _dBContext.SaveChanges();
        }

        public void AddBid(Bid bid, int id)
        {
            BidDB bdb = _mapper.Map<BidDB>(bid);
            AuctionDB auctionDB = _dBContext.AuctionDBs.Where(a => a.AuctionID == id).SingleOrDefault();

            var bidsDB = auctionDB.BidDBs.ToList();
            List<Bid> bids = new List<Bid>();
            foreach (BidDB b in bidsDB)
            {
                Bid b1 = _mapper.Map<Bid>(b);
                bids.Add(b1);
            }

            if (CanBidExecute(bid, bids) && bid.Amount > auctionDB.AskPrice)
            {
                auctionDB.BidDBs.Where(b => b.Amount > bdb.Amount);
                Auction auction = _mapper.Map<Auction>(auctionDB);
                auctionDB.BidDBs.Add(bdb);
                _dBContext.SaveChanges();
            }


        }

        public bool CanBidExecute(Bid bid, List<Bid> bids)
        {
            foreach (Bid b in bids)
            {
                if (bid.Amount <= b.Amount)
                {
                    return false;
                }
            }
            return true;
        }

        public void EditDescription(Auction auction)
        {
            var auctionDB = _dBContext.AuctionDBs.Where(a => a.AuctionID == auction.AuctionID).SingleOrDefault();

            auctionDB.Description = auction.Description;
            _dBContext.SaveChanges();

        }

        public Auction GetDescription(int id)
        {
            var auctionDB = _dBContext.AuctionDBs
                .Where(a => a.AuctionID == id)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDB);
            return auction;
        }

        public List<Auction> GetAll()
        {

            var auctionDB = _dBContext.AuctionDBs.Where(a => a.EndTime >= DateTime.Now).ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB adb in auctionDB)
            {
                Auction project = _mapper.Map<Auction>(adb);
                result.Add(project);
            }

            return result;
        }

        public List<Auction> GetAllByUsername(string username)
        {
            var auctionDBs = _dBContext.AuctionDBs.Where(a => a.Seller.Equals(username)).ToList();

            List<Auction> result = new List<Auction>();

            foreach (AuctionDB adb in auctionDBs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }

            return result;
        }

        public List<Auction> GetAuctions(string username)
        {
            var auctionDBs = _dBContext.AuctionDBs.AsEnumerable().Where(a => a.EndTime > DateTime.Now && _dBContext.BidDBs.Any(b => a.AuctionID == b.AuctionID && b.Bidder.Equals(username))).ToList();

            List<Auction> result = new List<Auction>();

            foreach (AuctionDB adb in auctionDBs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }

            return result;
        }

        public List<Auction> GetWins(string username)
        {
            var auctionDBs = _dBContext.AuctionDBs.Include(a => a.BidDBs).AsEnumerable().Where(a => a.EndTime < DateTime.Now && a.BidDBs.Any(b => a.AuctionID == b.AuctionID && b.Amount == a.BidDBs.Max(m => m.Amount) && b.Bidder.Equals(username))).ToList();

            List<Auction> result = new List<Auction>();

            foreach (AuctionDB adb in auctionDBs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }

            return result;
        }

        public Auction GetByID(int id)
        {
            var auctionDB = _dBContext.AuctionDBs
                .Include(a => a.BidDBs)
                .Where(a => a.AuctionID == id)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDB);
            foreach(BidDB bdb in auctionDB.BidDBs)
            {
                auction.addBid(_mapper.Map<Bid>(bdb));
            }

            return auction;
        }
    }
}
