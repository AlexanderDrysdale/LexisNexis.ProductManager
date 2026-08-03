namespace LexisNexis.ProductManager.Contracts.Data.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; } // nullable for root categories
    }
}
