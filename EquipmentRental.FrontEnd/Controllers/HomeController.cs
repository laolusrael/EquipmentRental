using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EquipmentRental.FrontEnd.Models;
using Microsoft.Extensions.Logging;
using EquipmentRental.FrontEnd.Services;
using EquipmentRental.FrontEnd.Models.Home;

namespace EquipmentRental.FrontEnd.Controllers
{
    public class HomeController : Controller
    {

        private IInventoryService _inventoryService;
        private ICartService _cartService;
        private ILogger<HomeController> _logger;
        public HomeController(IInventoryService inventoryService,
                    ICartService cartService,
                    ILogger<HomeController> logger)
        {
            _inventoryService = inventoryService;
            _cartService      = cartService;
            _logger           = logger;
        }
        public async Task<IActionResult> Index()
        {
            EquipmentOrderViewModel model = new EquipmentOrderViewModel();

            try
            {
                var equipments = await _inventoryService.GetEquipmentsAsync();
                if (equipments.Any())
                {
                    model.Equipments = equipments;
                }

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, nameof(Index));
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> AddToCart(EquipmentOrderViewModel model)
        {

            if (!ModelState.IsValid)
            {

                return View("Index", model);

            }


            try
            {


                if (!string.IsNullOrEmpty(model.DateRange))
                {
                    var startDate = DateTime.Parse(model.DateRange.Split("-")[0].Trim());
                    var endDate = DateTime.Parse(model.DateRange.Split("-")[1].Trim());

                    model.NumberOfDays = endDate.Subtract(startDate).Days;
                }
                else
                {
                    // Default to 1 day if date range is not selected
                    model.NumberOfDays = 1;
                }

                await _cartService
                        .AddEquipmentToCartAsync(
                            new CartItemModel
                            {
                                EquipmentId = model.SelectedEquipmentId,
                                NumberOfDays = model.NumberOfDays
                            });

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogDebug(ex, nameof(AddToCart));
                ModelState.AddModelError("", ex.Message);
            }

            return View("Index", model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
