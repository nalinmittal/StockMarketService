using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarket.Dtos
{
    class StockExchangeDto
    {
        public long Id { get; set; }
        [Required]
        public string Stockexchange { get; set; }
        [Required]
        public string Brief { get; set; }
        [Required]
        public string Contactaddress { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public List<int> Companies { get; set; }

    }
}
