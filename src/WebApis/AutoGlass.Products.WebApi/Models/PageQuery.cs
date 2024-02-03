namespace AutoGlass.Products.WebApi.Models
{
    public class PageQuery
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; } = null;
        public string OrderDirection { get; set; } = "asc";

    }
}
