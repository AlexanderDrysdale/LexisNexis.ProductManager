using LexisNexis.ProductManager.Contracts.Data.Repositories;

namespace LexisNexis.ProductManager.Contracts.Data
{
    public interface IUnitOfWork
    {
        INinjaRepository Ninjas { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        Task CommitAsync();
    }
}