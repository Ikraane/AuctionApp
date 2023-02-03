using ProjectApp.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApp.Persistence
{
    public class BidDB
    {
        [Key]
        public int BidID { get; set; }
        [Required]
        public string Bidder { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime BidDate { get; set; }

        [ForeignKey("AuctionID")]
        public AuctionDB AuctionDB { get; set; }

        public int AuctionID { get; set; }
    }
}
