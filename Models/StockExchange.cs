using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class StockExchange
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Stockexchange { get; set; }
        public string Brief { get; set; }
        public string Contactaddress { get; set; }
        public string Remarks { get; set; }

    }
}
