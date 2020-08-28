using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace Models
{
    public class Stockprice
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public virtual Company Company { get; set; }
        public virtual StockExchange Stockexchange { get; set; }
        public float Currentprice { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

    }
}
