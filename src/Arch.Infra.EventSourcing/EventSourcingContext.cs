using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Infra.EventSourcing
{
    public class EventSourcingContext: DbContext
    {
        public EventSourcingContext(DbContextOptions<EventSourcingContext> options)
            : base(options) { }

        
    }
}
