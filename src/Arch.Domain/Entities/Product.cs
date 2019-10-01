using Arch.Domain.Entities.Base;

namespace Arch.Domain.Entities
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}