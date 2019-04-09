using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Backend.DTO
{
    public class CartItemDto
    {
        public Guid EquipmentId { get; set; }
        public int NumberOfDays { get; set; }
    }
}
