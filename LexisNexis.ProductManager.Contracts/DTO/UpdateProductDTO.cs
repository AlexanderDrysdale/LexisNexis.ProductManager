namespace LexisNexis.ProductManager.Contracts.DTO
{
    // Used in PUT /api/products/{id}
    public record UpdateProductDTO(
        string Name,
        string Description,
        string SKU,
        decimal Price,
        int Quantity,
        int CategoryId
    );
}
