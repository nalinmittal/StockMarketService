using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models

{
    public class CompanyStockExchange
    {
        public Company Company { get; set; }
        public StockExchange StockExchange { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int StockExchangeId { get; set; }

    }

}