using System.Collections.Generic;
using Arch.Domain.Entities.Base;

namespace Arch.Domain.Entities
{
    public class Order: Entity
    {
        public ICollection<OrderItem> Items { get; set; }
    }
}