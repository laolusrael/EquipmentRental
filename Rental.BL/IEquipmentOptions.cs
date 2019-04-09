using System;

namespace Rental.BL
{
    public interface IEquipmentOptions {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        bool IsAvailable { get; set; }
        Guid Id { get; set; }
        string EquipmentName { get; set; }
    }

}
