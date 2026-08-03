using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Contracts.Data.Entities
{
    public class InventoryLog : BaseEntity
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public int ChangeAmount { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
