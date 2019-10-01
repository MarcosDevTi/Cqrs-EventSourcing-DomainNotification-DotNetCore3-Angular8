using Arch.Domain.Entities.Base;

namespace Arch.Domain.Entities
{
    public class OrderItem: Entity
    {
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}