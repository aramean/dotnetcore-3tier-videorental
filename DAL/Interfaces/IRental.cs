using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRental
    {
        Task<List<RentalItem>> GetAllRentalItems();
    }
}