using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarket.Dtos
{
    public class StockExchangeDto
    {
        public string Id { get; set; }
        [Required]
        public string Brief { get; set; }
        [Required]
        public string Contactaddress { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public List<int> CompanyIds { get; set; }

    }
}
