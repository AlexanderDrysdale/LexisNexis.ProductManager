namespace LexisNexis.ProductManager.Contracts.Data.Entities
{
    public class Product : BaseEntity, IComparable<Product>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;

            // Example: sort by Name alphabetically, then by Price if names are equal
            int nameComparison = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
            if (nameComparison != 0) return nameComparison;

            return Price.CompareTo(other.Price);
        }
    }
}
