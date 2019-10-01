using System.Collections.Generic;
using System.Linq;
using Arch.Infra.Shared.Search;

namespace Arch.Shared.Tests.Builders
{
    public class TextSearchBuilder
    {
        private string _searchTerm;
        private TextComparators _comparator = TextComparators.Contains;
        private string _property;
        private string _targetTypeName = typeof(ObjectTextSearchTest).AssemblyQualifiedName;

        public static TextSearchBuilder New(string searchTerm, string property) =>
         new TextSearchBuilder
         {
             _searchTerm = searchTerm,
             _property = property
         };

        public TextSearchBuilder WithSeachTerm(string term)
        {
            _searchTerm = term;
            return this;
        }

        public TextSearchBuilder WithComparator(TextComparators comparator)
        {
            _comparator = comparator;
            return this;
        }

        public TextSearch Build =>
             new TextSearch
            {
                SearchTerm = _searchTerm,
                Property = _property,
                TargetTypeName = _targetTypeName,
                Comparator = _comparator
            };
        
        public static IQueryable<ObjectTextSearchTest> ObjectTextSearchTestList =>
            new List<ObjectTextSearchTest>
                {
                    new ObjectTextSearchTest
                    {
                        Name = new Name {FirstName = "First Name"},
                        Email = "email@email.com",
                        ListSimpleObject = new [] {"simple item 1", "simple item 2", "simple item 3", "simple eitem 4"},
                        ListComplexObject = new [] { new Name { FirstName = "Name1 1" }, new Name { FirstName = "Name1 2" }, new Name { FirstName = "Name1 3" } }
                    },
                    new ObjectTextSearchTest
                    {
                        Name = new Name {FirstName = "First Name 2"},
                        Email = "email2@email.com",
                        ListSimpleObject = new [] {"simple2 item 1", "simple2 item 2", "simple2 item 2", "simple2 eitem 4"},
                        ListComplexObject = new [] { new Name { FirstName = "Name2 1" }, new Name { FirstName = "Name2 2" }, new Name { FirstName = "Name2 3" } }
                    }
                }.AsQueryable();
    }
}