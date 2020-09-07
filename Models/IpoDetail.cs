using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class IpoDetail
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public float Pricepershare { get; set; }
        [Required]
        public int Totalnumberofshares { get; set; }
        [Required]
        public DateTime Opendatetime { get; set; }
        [Required]
        public string Remarks { get; set; }
        //[Required]
        //public virtual CompanyStockExchange CompanyStockExchange { get; set; }
        [Required]
        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        [Required]
        [ForeignKey("StockExchange")]
        public string StockExchangeId { get; set; }


    }
}
