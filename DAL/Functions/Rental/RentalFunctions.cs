using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class RentalFunctions : IRental
    {
        // Get all rentals
        public async Task<List<RentalItem>> GetAllRentalItems()
        {
            List<RentalItem> rentals = new List<RentalItem>();
            using (var context = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                rentals = await context.RentalItems.ToListAsync();
            }
            return rentals;
        }

    }
}