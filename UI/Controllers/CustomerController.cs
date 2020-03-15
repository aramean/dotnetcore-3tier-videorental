using BLL.CustomerLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerLogic customerLogic = new CustomerLogic();

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var items = await customerLogic.GetAllCustomers();
            var model = new CustomersViewModel
            {
                PageTitle = "Customers",
                PageNoResultText = "No customers found!",
                Items = items
            };

            ViewBag.Title = "Customers";
            return View(model);
        }

        // GET: Customer/Rentals/5
        public async Task<IActionResult> Rentals(int id)
        {
            var customer = await customerLogic.GetCustomer(id);
            var items = await customerLogic.GetRentalsByCustomer(id);
            var customerspecialdiscount = customerLogic.CalculateSpecialDiscount(customer.CustomerId, (int)customer.CustomerType, items);

            var model = new CustomerRentalsViewModel
            {
                PageTitle = "Customer rentals",
                PageNoResultText = "No customer rentals found!",
                Items = items,
                SpecialDiscounts = customerspecialdiscount,
                CustomerName = customer.FirstName+" "+customer.LastName,
                CustomerType = (int) customer.CustomerType,
            };

            ViewBag.Title = "Customer rentals";
            return View(model);
        }

        // GET: Customer/Add
        public ActionResult Add()
        {
            var model = new CustomersAddViewModel
            {
                PageTitle = "Add customer"
            };

            ViewBag.Title = "Add customer";
            return View(model);
        }

        // POST: Customer/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(IFormCollection collection)
        {
            string firstname = collection["FirstName"];
            string lastname = collection["LastName"];
            string type = collection["CustomerType"];

            var result = await customerLogic.CreateNewCustomer(firstname, lastname, type);

            if (result)
                return RedirectToAction(nameof(Index));

            return View();
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await customerLogic.GetCustomer(id);
            
            if (customer == null)
            {
                return NotFound();
            }

            var model = new CustomerEditViewModel
            {
                PageTitle = "Edit customer",
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CustomerType = (int) customer.CustomerType
            };

            ViewBag.Title = "Edit customer";
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            string firstname = collection["FirstName"];
            string lastname = collection["LastName"];
            string type = collection["CustomerType"];

            var result = await customerLogic.EditCustomer(id, firstname, lastname, type);

            if (result == null)
                return View();

            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await customerLogic.DeleteCustomer(id);

            if (result)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }
    }
}