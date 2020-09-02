using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace Models
{
    public class StockPrice
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public virtual Company Company { get; set; }
        [Required]
        public virtual StockExchange Stockexchange { get; set; }
        [Required]
        public float CurrentPrice { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public virtual CompanyStockExchange CompanyStockExchange { get; set; }

    }
}
