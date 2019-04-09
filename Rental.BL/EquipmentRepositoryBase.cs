using System;
using System.Collections.Generic;
using System.Linq;

namespace Rental.BL
{
    /// <summary>
    /// Provides an abstract implementation of Equipment repository with default operations
    /// </summary>
    public abstract class EquipmentRepositoryBase : IEquipmentRepository
    {

        protected EquipmentRepositoryBase()
        {
            Equipments = new List<Equipment>();
        }

        public IEnumerable<Equipment> GetAll() => Equipments.ToList();

        protected List<Equipment> Equipments { get; set; }


        public virtual IEnumerable<Equipment> FilterEquipments(Func<Equipment, bool> expression)
        {
            return Equipments.Where(expression);
        }
        public virtual Equipment GetEquipmentById(Guid equipmentId)
        {

            return Equipments.FirstOrDefault(e => e.Id == equipmentId);
        }

        public  virtual Equipment GetEquipmentByName(string equipmentName)
        {
            return
            Equipments.FirstOrDefault(e => e.Name == equipmentName);
        }

        public virtual void SaveChanges() { }


        public virtual void AddEquipmentToRepository(Equipment equipment)
        {
            if(equipment == null && equipment.EquipmentType == EquipmentType.Abstract)
            {
                throw new ArgumentException("Equipment type not allowed");
            }

            if (Equipments.Any(e => e.EquipmentType == equipment.EquipmentType && e.Name == equipment.Name))
                return;


            Equipments.Add(equipment);
        }
    }

}
