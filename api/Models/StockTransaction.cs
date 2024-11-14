using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class StockTransaction
    {
        public int id { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }


    }
}