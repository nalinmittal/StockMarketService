﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarket.Dtos
{
    public class IpoDetailDto
    {
        public long Id { get; set; }
        [Required]
        public long CompanyId { get; set; }
        [Required]
        public string StockExchangeId { get; set; }
        [Required]
        public float Pricepershare { get; set; }
        [Required]
        public int Totalnumberofshares { get; set; }
        [Required]
        public DateTime Opendatetime { get; set; }
        public string Remarks { get; set; }
    }
}
