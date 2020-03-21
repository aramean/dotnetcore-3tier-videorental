using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Models
{
    public class RentalAddItemViewModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [StringLength(256, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        [Display(Name = "Image url")]
        public string ImageUrl { get; set; }
        [Range(0, 100000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Rental Item Type")]
        public int RentalItemType { get; set; }
    }
}