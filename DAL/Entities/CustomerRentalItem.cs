using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class CustomerRentalItem
    {
        [Key]
        public int CustomerRentalId { get; set; }
        public int RentalItemId { get; set; }
        public short Discount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public RentalItem RentalItem { get; set; }
    }
}
