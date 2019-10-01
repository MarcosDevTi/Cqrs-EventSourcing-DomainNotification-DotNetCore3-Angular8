using System.Collections.Generic;
using System.Linq;
using Arch.Infra.Shared.Search;
using Arch.Shared.Tests.Builders;
using Xunit;
using Xunit.Extensions;

namespace Arch.Shared.Tests.Search
{
    public class TextSearchTest
    {
        [Theory]
        [InlineData("email@em", TextComparators.Contains, 1)]
        [InlineData("email2@email.com", TextComparators.Contains, 1)]
        [InlineData("email", TextComparators.Contains, 2)]
        [InlineData("email@em", TextComparators.Equals, 0)]
        public void ApplyToQuery_EqualsText_CorrectResultReturned(string term, TextComparators comparator, int count)
        {
            var textSearch = TextSearchBuilder.New(term, "Email")
                .WithComparator(comparator)
                .Build;

            Assert.Equal(count, textSearch.ApplyToQuery(TextSearchBuilder.ObjectTextSearchTestList).Count());
        }

        [Theory]
        [InlineData("First Name", TextComparators.Contains, 2)]
        [InlineData("First Name", TextComparators.Equals, 1)]
        [InlineData("First", TextComparators.Equals, 0)]
        public void ApplyToQuery_EqualsText_CorrectResult_Complex_Object_Returned(string term, TextComparators comparator, int count)
        {
             var textSearch = TextSearchBuilder.New(term, "Name.FirstName")
                .WithComparator(comparator)
                .Build;

             Assert.Equal(count, textSearch.ApplyToQuery(TextSearchBuilder.ObjectTextSearchTestList).Count());
        }

        [Theory]
        [InlineData("simple", TextComparators.Contains, 2)]
        [InlineData("simple2 item 1", TextComparators.Equals, 1)]
        [InlineData("simple2 item 1r", TextComparators.Equals, 0)]
        public void ApplyToQuery_EqualsText_Collection_Simple_Objects(string term, TextComparators comparator, int count)
        {
             var textSearch = TextSearchBuilder.New(term, "ListSimpleObject")
                .WithComparator(comparator)
                .Build;

             Assert.Equal(count, textSearch.ApplyToQuery(TextSearchBuilder.ObjectTextSearchTestList).Count());
        }
        
        [Theory]
        [InlineData("Name", TextComparators.Contains, 2)]
        [InlineData("Name2 1", TextComparators.Equals, 1)]
        [InlineData("Name2 1r", TextComparators.Equals, 0)]
        public void ApplyToQuery_EqualsText_Collection_Complex_Objects(string term, TextComparators comparator, int count)
        {
             var textSearch = TextSearchBuilder.New(term, "ListComplexObject.FirstName")
                .WithComparator(comparator)
                .Build;

             Assert.Equal(count, textSearch.ApplyToQuery(TextSearchBuilder.ObjectTextSearchTestList).Count());
        }
    }
}