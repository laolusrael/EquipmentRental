using System;
using System.Collections.Generic;

namespace Rental.BL
{
    public class EquipmentInventory:IEquipmentInventory
    {

        public IEquipmentRepository _repository;
        public EquipmentInventory(IEquipmentRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Gets all available equipments
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Equipment> GetAvailableEquipments()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Gets equipment by Id
        /// </summary>
        /// <param name="equipmentId">Equipment Id</param>
        /// <returns></returns>
        public Equipment GetEquipmentById(Guid equipmentId)
        {

            return _repository.GetEquipmentById(equipmentId);
        }
        /// <summary>
        /// Gets equipment by name
        /// </summary>
        /// <param name="equipmentName">name of the equipment</param>
        /// <returns></returns>
        public Equipment GetEquipmentByName(string equipmentName)
        {
            return 
                _repository.GetEquipmentByName(equipmentName);
        }

        /// <summary>
        /// Adds a given equipment to the inventory
        /// </summary>
        /// <param name="equipment"></param>
        public void AddEquipmentToInventory(Equipment equipment)
        {
            _repository.AddEquipmentToRepository(equipment);
            _repository.SaveChanges();
        }
    }

}
