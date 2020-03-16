using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public enum CustomerTypeEnum
    {
        Regular = 0,
        Member = 1,
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }
        public ICollection<CustomerRentalItem> CustomerRentalItem { get; set; }
    }

}
