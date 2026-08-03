using LexisNexis.ProductManager.Contracts.Data.Entities;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
using LexisNexis.ProductManager.Migrations;

namespace LexisNexis.ProductManager.Core.Data.Repositories
{
    public class NinjaRepository : Repository<Ninja>, INinjaRepository
    {
        public NinjaRepository(DatabaseContext context) : base(context)
        {
        }
    }
}