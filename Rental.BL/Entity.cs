using System;

namespace Rental.BL
{
    public abstract class Entity : IEntity {

        protected Entity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
        }
        public Guid Id { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public DateTime DateModified { get; protected set; }

    }

}
