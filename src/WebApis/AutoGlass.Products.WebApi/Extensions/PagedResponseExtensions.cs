using AutoGlass.Products.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoGlass.Products.WebApi.Extensions
{
    public static class PagedResponseExtensions
    {
        public static PagedResponse<T> GetPagedListAsync<T>(IQueryable<T> query, PageQuery queryParameters)
        {
            var totalCount =  query.Count();

            int pageNumber = queryParameters.PageNumber.HasValue ? queryParameters.PageNumber.Value : 1;

            int pageSize = queryParameters.PageSize.HasValue ? queryParameters.PageSize.Value : totalCount;

            return DoPagination<T>(query, totalCount, pageNumber, pageSize, queryParameters.OrderBy, queryParameters.OrderDirection);
        }

        private static PagedResponse<T> DoPagination<T>(IQueryable<T> query, int totalCount, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            var itens = query;

            if (!string.IsNullOrEmpty(orderBy))
            {
                var property = GetProperty<T>(orderBy);

                if (property != null)
                {
                    if (orderDirection.ToLower() == "asc")
                        itens = itens.OrderBy(GetExpression<T>(property));
                    if (orderDirection.ToLower() == "desc")
                        itens = itens.OrderByDescending(GetExpression<T>(property));
                }
            }

            var response = itens
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResponse<T>(totalCount, response, pageNumber, pageSize);
        }

        public static PropertyInfo? GetProperty<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            PropertyInfo? property = typeof(T).GetProperty(propertyName);
            if (property is null)
            {
                throw new ArgumentException($"Property '{propertyName}' does not exist in '{typeof(T).Name}'.");
            }

            return property;
        }

        public static Expression<Func<T, object>> GetExpression<T>(PropertyInfo propertyInfo)
        {
            var parameterExpression = Expression.Parameter(typeof(T));
            var propertyAccess = Expression.Property(parameterExpression, propertyInfo);
            var castToObject = Expression.Convert(propertyAccess, typeof(object));
            return Expression.Lambda<Func<T, object>>(castToObject, parameterExpression);
        }

    }
}
