using System;

namespace Rental.BL
{
    /// <summary>
    /// Factory class for instantiating equipments
    /// </summary>
    public class EquipmentFactory : AbstractEquipmentFactory
    {
        /// <summary>
        /// Create instance of an equipment of specified type with given name
        /// </summary>
        /// <param name="equipmentName">name of the equipment</param>
        /// <param name="equipmentType">type of the equipment</param>
        /// <returns></returns>
        public override Equipment CreateEquipment(string equipmentName, EquipmentType equipmentType)
        {
           
            switch (equipmentType)
            {
                case EquipmentType.Heavy:
                    return new HeavyEquipment(equipmentName);
                case EquipmentType.Regular:
                    return new RegularEquipment(equipmentName);
                case EquipmentType.Specialized:
                    return new SpecializedEquipment(equipmentName);
                default:
                    return null;

            }

        }

        /// <summary>
        /// Creates  an equipment of given type using additional information about the equipment.
        /// This is useful when creating an equipment instance with data stored in a database
        /// </summary>
        /// <param name="equipmentType">Type of equipment to be created</param>
        /// <param name="configuration">Additional details about the equipment</param>
        /// <returns>Instance of Equipment configured as specified</returns>
        public override Equipment CreateEquipment(EquipmentType equipmentType, IEquipmentOptions configuration)
        {


            if (string.IsNullOrEmpty(configuration.EquipmentName))
                throw new ArgumentNullException($"{nameof(configuration.EquipmentName)}  is required");

            configuration.DateCreated = DateTime.MinValue == configuration.DateCreated ? DateTime.UtcNow : configuration.DateCreated;
            configuration.DateModified = DateTime.MinValue == configuration.DateModified ? DateTime.UtcNow : configuration.DateModified;
            configuration.IsAvailable = configuration.IsAvailable || true;
            configuration.Id = Guid.Empty != configuration.Id ? configuration.Id : Guid.NewGuid();


            switch (equipmentType)
            {
                case EquipmentType.Heavy:
                    return new HeavyEquipment(configuration.Id, configuration.EquipmentName, configuration.IsAvailable, configuration.DateCreated, configuration.DateModified);
                case EquipmentType.Regular:
                    return new RegularEquipment(configuration.Id, configuration.EquipmentName, configuration.IsAvailable, configuration.DateCreated, configuration.DateModified);
                case EquipmentType.Specialized:
                    return new SpecializedEquipment(configuration.Id, configuration.EquipmentName, configuration.IsAvailable, configuration.DateCreated, configuration.DateModified);
                default:
                    return null;

            }

        }

    }

}
