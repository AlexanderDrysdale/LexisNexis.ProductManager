using LexisNexis.ProductManager.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Infrastructure.Services
{
    public class SearchCacheService: ISearchCacheService
    {
        // Dictionary to hold cached results
        private readonly Dictionary<string, object> _cache = new();

        // Try to get cached result
        public bool TryGet(string query, out object? result)
        {
            return _cache.TryGetValue(query, out result);
        }

        // Add or update cache entry
        public void Set(string query, object result)
        {
            _cache[query] = result;
        }

        // Optional: clear cache
        public void Clear()
        {
            _cache.Clear();
        }
    }
}
