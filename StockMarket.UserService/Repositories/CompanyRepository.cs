using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace StockMarket.UserService.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private StockMarketContext context;

        public CompanyRepository(StockMarketContext context)
        {
            this.context = context;
        }

        public bool Add(Company entity)
        {
            try
            {
                this.context.Add(entity);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Company entity)
        {
            try
            {
                this.context.Remove(entity);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Company> Get()
        {
            var companies = this.context.Companies;
            return companies;
        }

        public Company Get(object key)
        {
            var company = this.context.Companies.Find(key);
            return company;
        }

        public bool Update(Company entity)
        {
            try
            {
                this.context.Entry(entity).State = EntityState.Modified;
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
