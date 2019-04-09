namespace Rental.BL
{
    public abstract class AbstractEquipmentFactory
    {
        public abstract Equipment CreateEquipment(string equipmentName, EquipmentType equipmentType);
        public abstract Equipment CreateEquipment(EquipmentType equipmentType, IEquipmentOptions configure);
    }

}
