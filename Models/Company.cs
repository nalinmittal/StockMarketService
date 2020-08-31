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
        [Required]
        public float Turnover { get; set; }
        [Required]
        public string Ceo { get; set; }
        [Required]
        public string Boardofdirectors { get; set; }
        [Required]
        public virtual ICollection<StockExchange> Stockexchanges { get; set; }
        [Required]
        public virtual Sector Sector { get; set; }
        [Required]
        public string Brief { get; set; }
        [Required]
        public string Stockcodes { get; set; }

    }
}
