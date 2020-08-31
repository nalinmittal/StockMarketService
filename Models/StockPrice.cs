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
        public virtual StockExchange Stockexchange { get; set; }
        public float CurrentPrice { get; set; }
        public DateTime TimeOfTransaction { get; set; }

    }
}
