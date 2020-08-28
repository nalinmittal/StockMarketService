using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        protected CompanyContext()
        {

        }

        public virtual DbSet<Company> Company { get; set; }

    }
}
