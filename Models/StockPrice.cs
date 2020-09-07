using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace Models
{
    public class StockPrice
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public float CurrentPrice { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        [Required]
        [ForeignKey("StockExchange")]
        public string StockExchangeId { get; set; }

    }
}
