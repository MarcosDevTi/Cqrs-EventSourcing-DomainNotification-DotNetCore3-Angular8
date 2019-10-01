using Arch.Infra.Shared.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Application.Models.Product
{
    public class CreateProduct: ProductCommand, ICommandCreate
    {
    }
}
