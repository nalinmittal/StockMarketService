﻿using System;
using System.ComponentModel.DataAnnotations;

namespace StockMarket.Dtos
{
    public class StockPriceDto
    {
        public string To { get; set; }
        public string From { get; set; }
        public int CompanyId { get; set; }
        public string StockExchangeId { get; set; }
    }
}
