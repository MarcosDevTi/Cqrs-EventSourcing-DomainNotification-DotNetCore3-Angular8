using System;

namespace Arch.Cqrs.Client.Models.CustomerModels
{
    public class CustomerItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
    }
}