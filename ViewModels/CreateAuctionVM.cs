using System.ComponentModel.DataAnnotations;

namespace ProjectApp.ViewModels
{
    public class CreateAuctionVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max length 128 characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Max length 128 characters")]
        public string Description { get; set; }
        [Required]
        public float AskPrice { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

       

    }
}
