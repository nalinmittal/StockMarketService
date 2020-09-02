using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarket.Dtos
{
    public class SectorDto
    {
        public int Id { get; set; }
        [Required]
        public string Sectorname { get; set; }
        [Required]
        public string Brief { get; set; }
        [Required]
        public List<int> CompanyIds { get; set; }
    }
}
