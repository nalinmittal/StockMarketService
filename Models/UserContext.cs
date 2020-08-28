using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class UserContext : DbContext
    {

        public UserContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        protected UserContext()
        {

        }

        public virtual DbSet<User> User { get; set; }

    }
}

