using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class IpoDetail
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public virtual Company Company { get; set; }
        [Required]
        public virtual StockExchange Stockexchange { get; set; }
        [Required]
        public float Pricepershare { get; set; }
        [Required]
        public int Totalnumberofshares { get; set; }
        [Required]
        public DateTime Opendatetime { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public virtual CompanyStockExchange CompanyStockExchange { get; set; }
    }
}
