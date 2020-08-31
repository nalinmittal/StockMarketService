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
        public virtual StockExchange Stockexchange { get; set; }
        public float Pricepershare { get; set; }
        public int Totalnumberofshares { get; set; }
        public string Opendatetime { get; set; }
        public string Remarks { get; set; }
    }
}
