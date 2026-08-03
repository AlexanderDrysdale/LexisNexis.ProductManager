using LexisNexis.ProductManager.Contracts.Data.Repositories;

namespace LexisNexis.ProductManager.Contracts.Data
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IInventoryLogRepository InventoryLogs { get; }

        Task CommitAsync();
    }
}