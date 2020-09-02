using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Models;

namespace StockMarket.UserService.Data
{
    
    public class StockMarketContext : DbContext
    {
        public StockMarketContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected StockMarketContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyStockExchange>()
                .HasKey(bc => new { bc.CompanyId, bc.StockExchangeId });
            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<IpoDetail> Ipos { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<StockExchange> StockExchanges { get; set; }
        public virtual DbSet<StockPrice> StockPrices { get; set; }
        public virtual DbSet<Account> Users { get; set; }
        public virtual DbSet<CompanyStockExchange> CompanyStockExchanges { get; set; }

    }
}
