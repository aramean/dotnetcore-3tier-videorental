using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.RentalLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class RentalController : Controller
    {
        private readonly RentalLogic rentalLogic = new RentalLogic();

        public async Task<IActionResult> Index(RentalViewModel model)
        {
            model.Items = await rentalLogic.GetAllRentals();

            ViewBag.PageTitle = "Rentals";
            ViewBag.PageNoResultText = "No rental items found!";
            ViewBag.Title = "Rentals";
            return View(model);
        }

        public IActionResult Add(RentalAddItemViewModel model)
        {
            ViewBag.PageTitle = "Add rental item";
            ViewBag.Title = "Add rental item";
            return View(model);
        }

        // POST: Rental/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(IFormCollection collection, RentalAddItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                string title = collection["Title"];
                decimal price = 0;
                string type = collection["Type"];

                var result = await rentalLogic.AddRentalItem(title, price, type);

                if (result)
                    return RedirectToAction(nameof(Index));
            }

            ViewBag.PageTitle = "Add rental item";
            ViewBag.Title = "Add rental item";
            return View(model);
        }
    }
}