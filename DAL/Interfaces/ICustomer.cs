using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomer
    {
        // Expose functions
        Task<Customer> AddCustomer(string firstname, string lastname, string type);
        Task<Customer> EditCustomer(int customerid, string firstname, string lastname, string type);
        Task<Customer> DeleteCustomer(int customerid);
        Task<Customer> GetCustomer(int customerid);
        Task<IList<Customer>> GetAllCustomer();
        Task<IList<CustomerRentalItem>> GetRentalsByCustomer(int customerid);
    }
}