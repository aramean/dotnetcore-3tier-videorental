using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRental
    {
        // Expose functions
        Task<RentalItem> AddRentalItem(string title, decimal price, string type);
        Task<List<RentalItem>> GetAllRentalItems();
    }
}