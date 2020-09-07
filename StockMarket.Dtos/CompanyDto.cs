using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarket.Dtos
{
    public class CompanyDto
    {
        public long Id { get; set; }
        [Required]
        public string Companyname { get; set; }
        [Required]
        public float Turnover { get; set; }
        [Required]
        public string Ceo { get; set; }
        [Required]
        public string Boardofdirectors { get; set; }
        [Required]
        public List<string> StockExchangeIds { get; set; }
        [Required]
        public int SectorId { get; set; }
        [Required]
        public string Brief { get; set; }
    }
}
