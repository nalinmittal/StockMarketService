using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class StockExchange
    {

        [Key]
        public string Stockexchange { get; set; }
        [Required]
        public string Brief { get; set; }
        [Required]
        public string Contactaddress { get; set; }
        [Required]
        public string Remarks { get; set; }
    }
}
