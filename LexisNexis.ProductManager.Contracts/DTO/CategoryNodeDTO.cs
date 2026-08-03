namespace LexisNexis.ProductManager.Contracts.DTO
{
    // Returned in GET /api/categories/tree (hierarchical structure)
    public record CategoryNodeDTO(
        int Id,
        string Name,
        string Description,
        List<CategoryNodeDTO> Children
    );
}
