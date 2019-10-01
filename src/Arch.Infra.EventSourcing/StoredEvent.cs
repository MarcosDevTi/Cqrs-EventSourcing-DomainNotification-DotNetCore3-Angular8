using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Infra.EventSourcing
{
    public class StoredEvent
    {
        public Guid Id { get; set; }
        public string Assembly { get; set; }
        public string Action { get; protected set; }
        public Guid AggregateId { get; set; }
        public string Who { get; set; }
        public string When { get; set; }
    }
}
