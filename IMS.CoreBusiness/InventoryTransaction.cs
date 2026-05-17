using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class InventoryTransaction
    {
        [Required]
        public int InventoryTransactionId { get; set; }
        public string PoNumber { get; set; } = string.Empty;

        [Required]
        public Inventory InventoryId { get; set; }
        [Required]
        public int QuantityBefore { get; set; }

        [Required]
        public InventoryTransactionType ActivityType { get; set; }

        [Required]
        public int QuantityAfter { get; set; }

        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]    
        public string DoneBy { get; set; } = string.Empty;

        [Required]
        public Inventory? Inventory { get; set; }
    }
}
