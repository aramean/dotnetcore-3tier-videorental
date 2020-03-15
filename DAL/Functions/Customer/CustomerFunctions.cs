using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class CustomerFunctions : ICustomer
    {
        // Add a new customer
        public async Task<Customer> AddCustomer(string firstname, string lastname, string type)
        {
            int.TryParse(type, out int enumValue); // Convert string to int

            var newCustomer = new Customer
            {
                FirstName = firstname,
                LastName = lastname,
                CustomerType = (CustomerTypeEnum)enumValue,
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                await context.Customers.AddAsync(newCustomer);
                await context.SaveChangesAsync();
            }
            return newCustomer;
        }

        // Delete a customer
        public async Task<Customer> DeleteCustomer(int customerid)
        {
            using var context = new DatabaseContext(DatabaseContext.ops.DbOptions);
            var removeCustomer = await context.Customers.SingleAsync(c => c.CustomerId == customerid);
            context.Remove(removeCustomer);
            await context.SaveChangesAsync();
            return removeCustomer;
        }

        // Edit a customer
        public async Task<Customer> EditCustomer(int customerid, string firstname, string lastname, string type)
        {
            int.TryParse(type, out int enumValue); // Convert string to int

            var customer = new Customer
            {
                FirstName = firstname,
                LastName = lastname,
                CustomerType = (CustomerTypeEnum)enumValue,
            };

            using (var context = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                var editCustomer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerid);
                editCustomer.FirstName = customer.FirstName;
                editCustomer.LastName = customer.LastName;
                editCustomer.CustomerType = customer.CustomerType;
                context.Entry(editCustomer).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            return customer;
        }

        // Get a customer
        public async Task<Customer> GetCustomer(int customerid)
        {
            var customer = new Customer();
            using (var context = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                customer = await context.Customers.SingleOrDefaultAsync(c => c.CustomerId == customerid);
            }

            return customer;
        }

        // Get all customers
        public async Task<IList<Customer>> GetAllCustomer()
        {
            IList<Customer> customers = new List<Customer>();
            using (var context = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                customers = await context.Customers.ToListAsync();
            }
            return customers;
        }
 
        // Get rentals of customer
        public async Task<IList<CustomerRentalItem>> GetRentalsByCustomer(int customerid)
        {
            IList<CustomerRentalItem> customerrentals = new List<CustomerRentalItem>();
            
            using (var context = new DatabaseContext(DatabaseContext.ops.DbOptions))
            {
                customerrentals  = await context.CustomersRentalItems.Include(r => r.RentalItem).Where(c => c.CustomerId == customerid).ToListAsync();
            }

            return customerrentals;
        }
    }
}
