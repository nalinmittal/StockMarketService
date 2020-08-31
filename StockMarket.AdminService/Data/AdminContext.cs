using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Data
{
    public class AdminContext : DbContext
    {
        public AdminContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected AdminContext()
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<StockExchange> StockExchanges { get; set; }
        public virtual DbSet<Ipodetail> Ipos { get; set; }
    }
}
