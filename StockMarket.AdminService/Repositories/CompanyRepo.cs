using Microsoft.EntityFrameworkCore;
using Models;
using StockMarket.AdminService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public class CompanyRepo : ICompanyRepo<Company>
    {
        private AdminContext context;

        public CompanyRepo(AdminContext context)
        {
            this.context = context;
        }

        public bool Add(Company entity)
        {
            try
            {
                this.context.Add(entity);
                int updates = context.SaveChanges();
                if(updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception)
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

        public IEnumerable<Company> GetMatching(string name)
        {
            var companies = this.context.Companies.Where(c => c.Companyname.Contains(name));
            return companies;
        }

        public bool Update(Company entity)
        {
            try
            {
                this.context.Entry(entity).State = EntityState.Modified;
                int updates = context.SaveChanges();
                if(updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
