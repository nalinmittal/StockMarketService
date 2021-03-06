﻿using System;
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
        //public Company()
        //{
        //    CompanyStockExchanges = new HashSet<CompanyStockExchange>();
        //}
        [Key]
        public long Id { get; set; }
        [Required]
        public string Companyname { get; set; }
        [Required]
        public float Turnover { get; set; }
        [Required]
        public string Ceo { get; set; }
        public string Boardofdirectors { get; set; }
        public virtual Sector Sector { get; set; }
        [Required]
        public string Brief { get; set; }

    }
}
