using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AutoGlass.Products.WebApi.Models
{
    public interface IPagedRespons<T>
    {
        int TotalCount { get; }
        IEnumerable<T> Items { get; }
    }

    public class PagedResponse<T> : IPagedRespons<T>
    {

        public int TotalCount { get; }
        public IEnumerable<T> Items { get; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; }

        public PagedResponse(int totalCount, IEnumerable<T> items, int pageNumber, int pageSize)
        {
            TotalCount = totalCount;
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

       
    }
}
