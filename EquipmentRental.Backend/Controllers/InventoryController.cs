using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental.BL;

namespace EquipmentRental.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController:ControllerBase
    {

        private readonly IEquipmentInventory _inventory;
        private readonly ILogger<InventoryController> _logger;
        public InventoryController(IEquipmentInventory inventory, ILogger<InventoryController> logger)
        {
            _inventory = inventory;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Equipment>> Get()
        {
            try
            {
                return
                  Ok(
                      _inventory
                          .GetAvailableEquipments()
                          );
            }
            catch(Exception ex)
            {
                _logger.LogDebug(ex, nameof(Get));
                return UnprocessableEntity(ex.Message);
            }
        }


    }
}
