using EquipmentRental.FrontEnd.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EquipmentRental.FrontEnd.Services
{
    public class CartService : ICartService
    {

        private readonly HttpClient _httpClient;
        private readonly ILogger<CartService> _logger;
        public CartService(IHttpClientFactory httpClientFactory, ILogger<CartService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("restClient");
            _logger = logger;
        }
        /// <summary>
        /// Sends requested equipment to the backend server
        /// </summary>
        /// <param name="model">Object represent the equipment and the number of days to rent it</param>
        /// <returns></returns>
        public async Task AddEquipmentToCartAsync(CartItemModel model)
        {

            try
            {
                var response = await _httpClient.PostAsJsonAsync<CartItemModel>("api/cart", model);
                
            }
            catch(Exception ex)
            {

                _logger.LogDebug(ex, nameof(AddEquipmentToCartAsync));
            }
            
        }
        /// <summary>
        /// Retrieves all cart items from the current session
        /// </summary>
        /// <returns>Enumerable list of cart items</returns>
        public async Task<IEnumerable<CartItemWithCostModel>> GetCartItemsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/cart");

                return 
                    await response
                            .Content
                            .ReadAsAsync<List<CartItemWithCostModel>>();
                
            }
            catch(Exception ex)
            {
                _logger.LogDebug(ex, nameof(GetCartItemsAsync));
            }


            return new List<CartItemWithCostModel>();

        }
    }
}
