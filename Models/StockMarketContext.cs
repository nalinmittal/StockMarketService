using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class StockMarketContext : DbContext
    {
        public StockMarketContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected StockMarketContext()
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Ipodetail> Ipos { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<StockExchange> StockExchanges { get; set; }
        public virtual DbSet<Stockprice> Stockprices { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
