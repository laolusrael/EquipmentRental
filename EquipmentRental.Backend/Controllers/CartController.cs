using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentRental.Backend.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental.BL;

namespace EquipmentRental.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ILogger<CartController> _logger;
        private readonly ICartManager _cartManager;
        private readonly IEquipmentInventory _inventory;
        public CartController(ICartManager cartManager, IEquipmentInventory inventory, ILogger<CartController> logger)
        {
            _logger = logger;
            _cartManager = cartManager;
            _inventory = inventory;
        }


        [HttpGet, Route("{customerNumber}")]
        public async Task<IActionResult> GetAsync(string customerNumber)
        {

            try
            {
                var cart = await _cartManager.GetCartByCustomerNumberAsync(customerNumber);
                return
                    Ok(cart);
            }

            catch(Exception ex)
            {

                _logger.LogError(ex, nameof(GetAsync));
            }

            return NotFound();
        }


        [HttpPost, Route("")]
        public async Task<IActionResult> PostAsync(CartItemDto cartItem)
        {

            try
            {

                var equipment = _inventory.GetEquipmentById(cartItem.EquipmentId);
                if (equipment == null)
                    return NotFound($"Equipment {cartItem.EquipmentId} not found in the inventory");

                return
                    Ok( await _cartManager.AddItemToCartAsync(equipment, cartItem.NumberOfDays));

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, nameof(PostAsync));
            }

            return BadRequest();
        }
    }
}