using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Arch.Infra.Shared.Paging
{
    public class PagedResult<T> : IEnumerable<T>
    {
        public PagedResult(IEnumerable<T> items, int total, Paging<T> paging)
        {
            Items = items.ToList();
            Total = total;
            Paging = paging;
        }

        public IReadOnlyList<T> Items { get; private set; }

        public Paging<T> Paging { get; private set; }

        public int Total { get; private set; }

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
    }
}
