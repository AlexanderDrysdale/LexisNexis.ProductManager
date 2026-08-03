using LexisNexis.ProductManager.Contracts.Data.Entities;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
using LexisNexis.ProductManager.Migrations;
using Microsoft.EntityFrameworkCore;

namespace LexisNexis.ProductManager.Core.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public DatabaseContext Context { get; }
        public ProductRepository(DatabaseContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Enumerable.Empty<Product>();

            return Context.Products
                .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
                .ToList();

        }
    }
}