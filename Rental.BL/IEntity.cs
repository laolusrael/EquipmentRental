using System;

namespace Rental.BL
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime DateCreated { get; }
        DateTime DateModified { get; }
    }

}
