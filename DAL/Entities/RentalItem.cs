using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public enum RentalItemTypeEnum
    {
        [Display(Name = "DVD")]
        DVD = 0,
        [Display(Name = "Blu-Ray")]
        BLURAY = 1,
    }

    public class RentalItem
    {
        [Key]
        public int RentalItemId { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public RentalItemTypeEnum RentalItemType { get; set; }
        public CustomerRentalItem CustomerRentalItem { get; set; }
    }
}
