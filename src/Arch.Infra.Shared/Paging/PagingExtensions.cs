using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Arch.Infra.Shared.Search;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Arch.Infra.Shared.Paging
{
    public static class PagingExtensions
    {

        private static readonly List<Type> Collections = new List<Type> { typeof(IEnumerable<>), typeof(IEnumerable) };

        private static Paging<TOut> Conversor<TIn, TOut>(Paging<TIn> entrada)
        {
            return new Paging<TOut>
            {
                SortColumn = entrada.SortColumn,
                Top = entrada.Top,
                Skip = entrada.Skip,
                SortDirection = entrada.SortDirection
            };
        }

        public static PagedResult<T2> GetPagedResult<T, T2>(this IQueryable<T> dbSet, IMapper mapper, Paging<T> paging) =>        
            new PagedResult<T2>(dbSet.SortAndPage2<T, T2>(mapper, paging), dbSet.Count(), Conversor<T, T2>(paging));

        public static IEnumerable<T2> SortAndPage2<T, T2>(this IQueryable<T> dbSet, IMapper mapper, Paging<T> paging)
        {
            var parameter = Expression.Parameter(typeof(T), "p");

            if (paging == null)
            {
                return mapper.Map<IEnumerable<T2>>(dbSet);
            }

            if (string.IsNullOrEmpty(paging.SortColumn))
            {
                paging.SortColumn = typeof(T)
                    .GetProperties()
                    .First(p => p.PropertyType == typeof(string)
                                || !p.PropertyType.GetInterfaces()
                                    .Any(i => Collections.Any(c => i == c)))
                    .Name;
            }

            var command = paging.SortDirection == SortDirection.Descending ? "OrderByDescending" : "OrderBy";

            var parts = paging.SortColumn.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            var property = typeof(T).GetProperty(parts[0]);
            var member = Expression.MakeMemberAccess(parameter, property);
            for (var i = 1; i < parts.Length; i++)
            {
                property = property.PropertyType.GetProperty(parts[i]);
                member = Expression.MakeMemberAccess(member, property);
            }

            var orderByExpression = Expression.Lambda(member, parameter);

            var resultExpression = Expression.Call(
                typeof(Queryable),
                command,
                new[] { typeof(T), property.PropertyType },
                dbSet.Expression,
                Expression.Quote(orderByExpression));

            dbSet = dbSet.Provider.CreateQuery<T>(resultExpression);
            return mapper.Map<IEnumerable<T2>>(dbSet.Skip(paging.Skip).Take(paging.Top));
        }
    }
}