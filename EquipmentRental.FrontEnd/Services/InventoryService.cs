using EquipmentRental.FrontEnd.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EquipmentRental.FrontEnd.Services { 

    /// <summary>
    /// Communication broker between the frontend controller and inventory management
    /// </summary>
    public class InventoryService:IInventoryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<InventoryService> _logger;
        public InventoryService(IHttpClientFactory httpClientFactory, ILogger<InventoryService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("restClient");
            _logger = logger;
        }


        /// <summary>
        /// Asynchronously gets all equipments that are available in the inventory
        /// </summary>
        /// <returns>List of all available equipment</returns>
        public async Task<IEnumerable<EquipmentModel>> GetEquipmentsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/inventory");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var result = await response.Content.ReadAsAsync<List<EquipmentModel>>();
                    return result;
                }

            }
            catch(Exception ex)
            {
                _logger.LogDebug(ex, nameof(GetEquipmentsAsync));
                throw;
            }


            return new List<EquipmentModel>();

        }       
       
    }
}
