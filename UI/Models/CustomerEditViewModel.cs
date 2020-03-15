using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class CustomerEditViewModel
    {
        public string PageTitle { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Customer Type")]
        public int CustomerType { get; set; }
    }
}
