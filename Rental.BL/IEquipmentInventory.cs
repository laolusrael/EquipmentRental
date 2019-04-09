using System;
using System.Collections.Generic;

namespace Rental.BL
{
    public interface IEquipmentInventory
    {
        IEnumerable<Equipment> GetAvailableEquipments();
        Equipment GetEquipmentByName(string equipmentName);
        Equipment GetEquipmentById(Guid equipmentId);
        void AddEquipmentToInventory(Equipment equipment);
    }

}
