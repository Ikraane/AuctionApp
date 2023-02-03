using ProjectApp.Core;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Persistence
{
    public class AuctionDB
    {
        [Key]
        public int AuctionID { get; set; }
       
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public string Seller { get; set; }

        public double AskPrice { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        public DateTime EndTime { get; set; }
        public List<BidDB> BidDBs { get; set; } = new List<BidDB>();
    }
}
