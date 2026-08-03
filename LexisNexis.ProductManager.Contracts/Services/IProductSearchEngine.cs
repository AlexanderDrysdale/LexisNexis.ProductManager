using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Contracts.Services
{
    public interface IProductSearchEngine
    {
        List<string> SearchOption(List<string> words, string query);
    }
}
