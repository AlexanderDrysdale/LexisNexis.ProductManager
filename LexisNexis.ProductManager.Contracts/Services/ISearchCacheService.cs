using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Contracts.Services
{
    public interface ISearchCacheService
    {
        void Clear();
        void Set(string query, object result);
        bool TryGet(string query, out object? result);
    }
}
