using LexisNexis.ProductManager.Contracts.Data.Entities;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
using LexisNexis.ProductManager.Migrations;
using Microsoft.EntityFrameworkCore;

namespace LexisNexis.ProductManager.Core.Data.Repositories
{
    public class InventorylogRepository : Repository<InventoryLog>, IInventoryLogRepository
    {
        public DatabaseContext Context { get; }
        public InventorylogRepository(DatabaseContext context) : base(context)
        {
            Context = context;
        }
    }
}