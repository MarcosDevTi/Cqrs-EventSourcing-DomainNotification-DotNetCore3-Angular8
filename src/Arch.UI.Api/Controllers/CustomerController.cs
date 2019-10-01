using Arch.Cqrs.Client.Models.Customer;
using Arch.Infra.Shared.Cqrs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arch.UI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IProcessor _processor;
        public CustomerController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateCustomer(CreateCustomer createCustomer)
        {
            var result = _processor.Send(createCustomer);
            return Ok(result);
        }

        [HttpPost]
        [Route("list")]
        public IActionResult GetCustomers(CustomersQuery customersQuery)
        {
            return Ok(_processor.Get(customersQuery));
        }

        [Route("{id:Guid}")]
        [HttpGet]
        public IActionResult GetCustomer(Guid id)
        {
            return Ok(_processor.Get(new GetCustomer(id)));
        }
    }
}
