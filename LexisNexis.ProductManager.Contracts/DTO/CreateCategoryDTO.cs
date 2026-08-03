namespace LexisNexis.ProductManager.Contracts.DTO
{
    // Used in POST /api/categories
    public record CreateCategoryDTO(
        string Name,
        string Description,
        int? ParentCategoryId
    );
}
