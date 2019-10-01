using System.Collections.Generic;

namespace Arch.Shared.Tests.Builders
{
    public class ObjectTextSearchTest
    {
        public Name Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> ListSimpleObject { get; set; }
        public IEnumerable<Name> ListComplexObject { get; set; }
    }

    public class Name { public string FirstName { get; set; }}

}