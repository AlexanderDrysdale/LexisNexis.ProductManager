using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Contracts.DTO
{
    public class AdjustInventoryDTO
    {
        public int ProductId { get; set; }
        public int QuantityChange { get; set; } // positive for restock, negative for sale
        public string Reason { get; set; } = string.Empty;
    }
}
