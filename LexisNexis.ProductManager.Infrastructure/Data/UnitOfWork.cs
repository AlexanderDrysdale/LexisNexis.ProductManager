using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
using LexisNexis.ProductManager.Core.Data.Repositories;
using LexisNexis.ProductManager.Migrations;

namespace LexisNexis.ProductManager.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IProductRepository Products => new ProductRepository(_context);
        public ICategoryRepository Categories => new CategoryRepository(_context);
        public IInventoryLogRepository InventoryLogs => new InventorylogRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}