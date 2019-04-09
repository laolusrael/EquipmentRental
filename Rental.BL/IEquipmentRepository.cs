using System;
using System.Collections.Generic;

namespace Rental.BL
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAll();
        IEnumerable<Equipment> FilterEquipments(Func<Equipment, bool> expression);
        Equipment GetEquipmentByName(string equipmentName);
        Equipment GetEquipmentById(Guid equipmentId);
        void AddEquipmentToRepository(Equipment equipment);

        void SaveChanges();
    }

}
