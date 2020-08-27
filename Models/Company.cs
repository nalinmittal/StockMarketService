using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [Table("company")]
    class Company
    {
        [Key]
        public long id { get; set; }
        [Required]
        [Column("cname")]
        public string Companyname { get; set; }
        [Column("turnover")]
        public float Turnover { get; set; }
        [Column("ceo")]
        public string Ceo { get; set; }
        [Column("bodirectors")]
        public string Boardofdirectors { get; set; }
        [Column("sexchanges")]
        public string Stockexchanges { get; set; }
        [Column("sector")]
        public string Sector { get; set; }
        [Column("brief")]
        public string Brief { get; set; }
        [Column("scodes")]
        public string Stockcodes { get; set; }

    }
}
