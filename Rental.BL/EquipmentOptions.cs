using System;

namespace Rental.BL
{
    public class EquipmentOptions: IEquipmentOptions{
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsAvailable { get; set; }
        public Guid Id { get; set; }
        public string EquipmentName { get; set; }

    }

}
