using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Companyname { get; set; }
        public float Turnover { get; set; }
        public string Ceo { get; set; }
        public string Boardofdirectors { get; set; }
        public virtual ICollection<StockExchange> Stockexchanges { get; set; }
        public Sector Sector { get; set; }
        public string Brief { get; set; }
        public string Stockcodes { get; set; }

    }
}
