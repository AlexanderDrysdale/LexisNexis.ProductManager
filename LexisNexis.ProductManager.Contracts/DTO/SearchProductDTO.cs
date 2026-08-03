namespace LexisNexis.ProductManager.Contracts.DTO
{
    public class SearchProductDTO
    {
        // default page number to 1
        public int PageNumber { get; set; } = 1;
        // default page size to 10
        public int PageSize { get; set; } = 10;
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
