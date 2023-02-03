using ProjectApp.Core;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.ViewModels
{
    public class EditVM
    {
        
        public int AuctionID { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Max length 128 characters")]
        public string Description { get; set; }

        public static EditVM FromDescription(string description)
        {
            return new EditVM()
            {
                Description = description
            };

        }
    }
}
