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

        public IActionResult Add()
        {
            ViewBag.PageTitle = "Add rental item";
            ViewBag.Title = "Add rental item";
            return View();
        }

        // POST: Rental/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Title", "Price", "Type")] RentalAddItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await rentalLogic.AddRentalItem(model.Title, model.Price, model.RentalItemType.ToString());
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            ViewBag.PageTitle = "Add rental item";
            ViewBag.Title = "Add rental item";
            return View(model);
        }
    }
}