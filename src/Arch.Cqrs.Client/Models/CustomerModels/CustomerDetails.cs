using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Cqrs.Client.Models.CustomerModels
{
    public class CustomerDetails
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
