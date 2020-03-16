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
        public async Task<IActionResult> Index(CustomersViewModel model)
        {
            var items = await customerLogic.GetAllCustomers();
            model.Items = items;

            ViewBag.PageTitle = "Customers";
            ViewBag.PageNoResultText = "No customers found!";
            ViewBag.Title = "Customers";
            return View(model);
        }

        // GET: Customer/Rentals/5
        public async Task<IActionResult> Rentals(int id, CustomerRentalsViewModel model)
        {
            var customer = await customerLogic.GetCustomer(id);
            var items = await customerLogic.GetRentalsByCustomer(id);
            var customerspecialdiscount = customerLogic.CalculateSpecialDiscount(customer.CustomerId, (int)customer.CustomerType, items);

            model.Items = items;
            model.SpecialDiscounts = customerspecialdiscount;
            model.CustomerName = customer.FirstName + " " + customer.LastName;
            model.CustomerType = (int)customer.CustomerType;

            ViewBag.PageTitle = "Customer rentals";
            ViewBag.PageNoResultText = "No customer rentals found!";
            ViewBag.Title = "Customer rentals";
            return View(model);
        }

        // GET: Customer/Add
        public ActionResult Add(CustomersAddViewModel model)
        {
            ViewBag.PageTitle = "Add customer";
            ViewBag.Title = "Add customer";
            return View(model);
        }

        // POST: Customer/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(IFormCollection collection, CustomersAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                string firstname = collection["FirstName"];
                string lastname = collection["LastName"];
                string type = collection["CustomerType"];

                var result = await customerLogic.CreateNewCustomer(firstname, lastname, type);

                if (result)
                    return RedirectToAction(nameof(Index));
            }

            ViewBag.PageTitle = "Add customer";
            ViewBag.Title = "Add customer";
            return View(model);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int id, CustomerEditViewModel model)
        {
            var customer = await customerLogic.GetCustomer(id);
            
            if (customer == null)
                return NotFound();

            model.FirstName = customer.FirstName;
            model.LastName = customer.LastName;
            model.CustomerType = (int)customer.CustomerType;

            ViewBag.PageTitle = "Edit customer";
            ViewBag.Title = "Edit customer";
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection, CustomerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                string firstname = collection["FirstName"];
                string lastname = collection["LastName"];
                string type = collection["CustomerType"];

                var result = await customerLogic.EditCustomer(id, firstname, lastname, type);

                if (result != null)
                    return RedirectToAction(nameof(Index));
            }

            ViewBag.PageTitle = "Edit customer";
            ViewBag.Title = "Edit customer";
            return View(model);
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