using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class CustomersAddViewModel
    {
        public string PageTitle { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Customer Type")]
        public int CustomerType { get; set; }
    }
}
