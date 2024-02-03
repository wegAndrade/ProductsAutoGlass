using AutoGlass.Products.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutoGlass.Products.WebApi.Extensions
{
    public static class PagedResponseExtensions
    {
        public static async Task<PagedResponse<T>> GetPagedListAsync<T>(IQueryable<T> query, PageQuery queryParameters)
        {
            var totalCount = await query.CountAsync();

            int pageNumber = queryParameters.PageNumber.HasValue ? queryParameters.PageNumber.Value : 1;

            int pageSize = queryParameters.PageSize.HasValue ? queryParameters.PageSize.Value : totalCount;

            return await DoPagination<T>(query, totalCount, pageNumber, pageSize, queryParameters.OrderBy, queryParameters.OrderDirection);
        }

        public static async Task<PagedResponse<T>> DoPagination<T>(IQueryable<T> query, int totalCount, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            var itens = query;

            var property = GetProperty<T>(orderBy);

            if (property != null)
            {
                if (orderDirection.ToLower() == "asc")
                    itens = itens.OrderBy(t => property);
                if (orderDirection.ToLower() == "desc")
                    itens = itens.OrderByDescending(t => property);
            }

            var response = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResponse<T>(totalCount, response, pageNumber, pageSize);
        }
        public static PropertyInfo? GetProperty<T>(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
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
    }
}
