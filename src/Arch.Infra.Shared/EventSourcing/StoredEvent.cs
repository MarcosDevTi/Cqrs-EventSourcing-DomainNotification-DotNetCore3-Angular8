using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Infra.Shared.EventSourcing
{
    public class StoredEvent
    {
        public string Assembly { get; set; }
        public Guid Id { get; set; }

        public string Data { get; set; }

        public string User { get; set; }
    }
}
