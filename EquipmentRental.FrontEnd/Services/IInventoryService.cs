using EquipmentRental.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.FrontEnd.Services
{
    public interface IInventoryService {
        Task<IEnumerable<EquipmentModel>> GetEquipmentsAsync();
    }
}
