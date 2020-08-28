using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IpodetailContext : DbContext
    {

        public IpodetailContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        protected IpodetailContext()
        {

        }

        public virtual DbSet<Ipodetail> Ipodetail { get; set; }

    }
}

