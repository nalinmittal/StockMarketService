using System;
using System.ComponentModel.DataAnnotations;

namespace StockMarket.Dtos
{
    public class StockPriceDto
    {
        public DateTime to { get; set; }
        public DateTime from { get; set; }
        public int CompanyId { get; set; }
        public string StockExchangeId { get; set; }
    }
}
