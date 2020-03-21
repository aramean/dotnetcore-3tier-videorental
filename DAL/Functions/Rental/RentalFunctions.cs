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

        public async Task<RentalItem> AddRentalItem(string title, decimal price, string type)
        {
            int.TryParse(type, out int enumValue); // Convert string to int
            //decimal.TryParse(price, out decimal price);// Convert string to decimal

            var newRentalItem = new RentalItem
            {
                Title = title,
                RentalItemType = (RentalItemTypeEnum)enumValue,
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                await context.RentalItems.AddAsync(newRentalItem);
                await context.SaveChangesAsync();
            }
            return newRentalItem;
        }

    }
}