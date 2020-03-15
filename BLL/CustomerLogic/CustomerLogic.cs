using DAL.Entities;
using DAL.Functions;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.CustomerLogic
{
    public class CustomerLogic
    {
        private readonly ICustomer _customer = new CustomerFunctions(); // Instantiate interface

        // Add new customer
        public async Task<Boolean> CreateNewCustomer(string firstname, string lastname, string type)
        {
            try
            {
                var result = await _customer.AddCustomer(firstname, lastname, type);
                if (result.CustomerId > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get customer by id
        public async Task<Customer> GetCustomer(int customerid)
        {
            var result = await _customer.GetCustomer(customerid);
            return result;
        }

        // Edit customer by id
        public async Task<Customer> EditCustomer(int customerid, string firstname, string lastname, string type)
        {
            var result = await _customer.EditCustomer(customerid, firstname, lastname, type);
            return result;
        }

        // Delete customer
        public async Task<Boolean> DeleteCustomer(int customerid)
        {
            try
            {
                var result = await _customer.DeleteCustomer(customerid);
                if (result.CustomerId > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get all customers
        public async Task<IList<Customer>> GetAllCustomers()
        {
            var result = await _customer.GetAllCustomer();
            return result;
        }
        
        // Get all rentals of customer
        public async Task<IList<CustomerRentalItem>> GetRentalsByCustomer(int customerid)
        {
            var result = await _customer.GetRentalsByCustomer(customerid);
            return result;
        }

        // Calculate discounts of customer
        public Decimal CalculateSpecialDiscount(int customerid, int customertype, IList<CustomerRentalItem> items)
        {
            int total = items.Count;
            decimal discount = 0;

            // Do calculations only if member
            if (customertype == 1)
            {
                decimal maxCheapestTotalPrice = 100;
                decimal cheapestTotalPrice = 0;
                decimal expensiveTotalPrice = 0;

                // Create empty list
                List<decimal> itemList = new List<decimal>();
                
                // Add all rental items with only the price to the list 
                foreach (var item in items)
                    itemList.Add(item.RentalItem.Price);

                // Sort the list, putting the cheapest first and expensive last
                itemList.Sort();

                // Take the 4 cheapeast from the list
                var cheapeastItems = itemList.GetRange(0,4);

                // Take all the expensive from the list skipping 4
                var expensiveItems = itemList.GetRange(4, (total - 4));

                // Sum total price for cheapeast and expensive items
                for (int i = 0; i <= cheapeastItems.Count - 1; i++)
                    cheapestTotalPrice += cheapeastItems[i];
                for (int i = 0; i <= expensiveItems.Count - 1; i++)
                    expensiveTotalPrice += expensiveItems[i];
                // 

                // If the total price of cheapeast is above 100 SEK do discount              
                if (cheapestTotalPrice >= maxCheapestTotalPrice)
                {
                    discount = cheapestTotalPrice - maxCheapestTotalPrice;
                }

                Console.WriteLine("Discount:" + discount);
            }
            else
            {
                discount = 0;
            }

            return discount;
        }
    }
}
