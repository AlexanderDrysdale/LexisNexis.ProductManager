namespace LexisNexis.ProductManager.Contracts.DTO
{
    // Used in POST /api/products
    public record CreateProductDTO(
        string Name,
        string Description,
        string SKU,
        decimal Price,
        int Quantity,
        int CategoryId
    );
}
