using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Infra.Shared.Search
{
    public class Search<TDomain>
    {
        public TDomain Domain { get; set; }
        public List<(string Property, string Comparator)> Properties { get; set; }
    }
}
