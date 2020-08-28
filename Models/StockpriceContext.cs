using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class StockpriceContext : DbContext
    {

        public StockpriceContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        protected StockpriceContext()
        {

        }

        public virtual DbSet<Stockprice> Stockprice { get; set; }

    }
}

