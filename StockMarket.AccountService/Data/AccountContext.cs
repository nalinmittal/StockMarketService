using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace StockMarket.AccountService.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext([NotNullAttribute] Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options)
        {
        }

        protected AccountContext()
        {
        }

        public virtual DbSet<Account> AccountUsers { get; set; }
    }
}
