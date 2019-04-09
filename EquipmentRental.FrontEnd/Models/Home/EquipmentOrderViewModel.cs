using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.FrontEnd.Models.Home
{
    public class EquipmentOrderViewModel
    {
        public EquipmentOrderViewModel()
        {
            Equipments = new List<EquipmentModel>();
        }
        public IEnumerable<EquipmentModel> Equipments { get; set; }
        public EquipmentModel SelectedEquipment { get; set; }
        public string DateRange { get; set; }

        public int NumberOfDays { get; set; }
        public Guid SelectedEquipmentId { get; set; }

    }
}
