using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.RentalLogic;
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
    }
}