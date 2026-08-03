namespace LexisNexis.ProductManager.Contracts.DTO
{
    // Returned in GET /api/categories (flat list)
    public record CategoryDTO(
        int Id,
        string Name,
        string Description,
        int? ParentCategoryId
    );
}
