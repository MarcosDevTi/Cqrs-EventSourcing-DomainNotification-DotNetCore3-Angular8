using System;
using Arch.Domain.Entities.Base;
using Arch.Domain.Entities.ValueObjects;

namespace Arch.Domain.Entities
{
    public class Customer: Entity
    {
        public Name Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public DateTime BirthDate { get; set; }
    }
}