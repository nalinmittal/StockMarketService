using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class StockExchangeContext : DbContext
    {
        
            public StockExchangeContext([NotNullAttribute] DbContextOptions options) : base(options)
            {

            }

            protected StockExchangeContext()
            {

            }

            public virtual DbSet<StockExchange> StockExchange { get; set; }

    }
}

