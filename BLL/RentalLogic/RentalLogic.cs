using DAL.Entities;
using DAL.Functions;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RentalLogic
{
    public class RentalLogic
    {
        private readonly IRental _rental = new RentalFunctions(); // Instantiate interface
        // Get all rentals
        public async Task<List<RentalItem>> GetAllRentals()
        {
            List<RentalItem> rentals = await _rental.GetAllRentalItems();
            return rentals;
        }
    }
}
