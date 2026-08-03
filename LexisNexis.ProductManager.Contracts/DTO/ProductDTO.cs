namespace LexisNexis.ProductManager.Contracts.DTO
{
    // Returned in GET endpoints
    public record ProductDTO(
        int Id,
        string Name,
        string Description,
        string SKU,
        decimal Price,
        int Quantity,
        int CategoryId
    );
}
