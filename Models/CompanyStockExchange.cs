using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models

{
    public class CompanyStockExchange
    {
        public Company Company { get; set; }
        public StockExchange StockExchange { get; set; }
        [Required]
        public long CompanyId { get; set; }
        [Required]
        //[ForeignKey("StockExchange")]
        public string StockExchangeId { get; set; }

    }

}