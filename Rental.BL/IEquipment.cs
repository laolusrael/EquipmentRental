namespace Rental.BL
{
    public interface IEquipment : IEntity
    {
        EquipmentType EquipmentType { get; }
        string Name { get; }
        bool IsAvailable { get; }
    }

}
