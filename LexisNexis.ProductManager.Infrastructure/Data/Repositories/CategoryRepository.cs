using LexisNexis.ProductManager.Contracts.Data.Entities;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
using LexisNexis.ProductManager.Migrations;
using Microsoft.EntityFrameworkCore;

namespace LexisNexis.ProductManager.Core.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public DatabaseContext Context { get; }
        public CategoryRepository(DatabaseContext context) : base(context)
        {
            Context = context;
        }
    }
}