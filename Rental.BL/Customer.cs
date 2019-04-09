using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.BL
{
    public class Customer:Entity
    {

        public Customer(string fullname, string phoneNumber)
            :this(Guid.NewGuid(), fullname, phoneNumber, DateTime.UtcNow, DateTime.UtcNow)
        {
        }
        public Customer(Guid id, string fullname, string phoneNumber, DateTime dateCreated, DateTime dateModified)
        {
            Name         = fullname;
            PhoneNumber  = PhoneNumber;
            Id           = id;
            DateCreated  = dateCreated;
            DateModified = dateModified;

        }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
    }

}
