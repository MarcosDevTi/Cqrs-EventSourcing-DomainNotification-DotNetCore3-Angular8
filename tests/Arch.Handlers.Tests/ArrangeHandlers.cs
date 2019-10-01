using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arch.Infra.Shared.Cqrs;

namespace Arch.Handlers.Tests
{
     public class CreateObject: ICommand { public string Name { get; set; }}
    public class GetObjects: IQuery<IEnumerable<CreateObject>> {}
    public class ObjectCommandHandler : ICommandHandler<CreateObject>
    {
        public CreateObject Handle(CreateObject command)
        {
            return new CreateObject { Name = "Test Name"};
        }
    }

    public class ObjectQueryHandler : IQueryHandler<GetObjects, IEnumerable<CreateObject>>
    {
        public IEnumerable<CreateObject> Handle(GetObjects query)
        {
            return new List<CreateObject>
            {
                new CreateObject { Name = "Test Name"}
            };
        }
    }
}