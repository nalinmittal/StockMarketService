using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserService.Repositories
{
    public class IpodetailRepository : IRepository<Ipodetail>

    {
        private StockMarketContext context;

        public IpodetailRepository(StockMarketContext context)
        {
            this.context = context;
        }

        public bool Add(Ipodetail entity)
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

        public bool Delete(Ipodetail entity)
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

        public IEnumerable<Ipodetail> Get()
        {
            var ipodetails = this.context.Ipos;
            return ipodetails;
        }

        public Ipodetail Get(object key)
        {
            var ipodetail = this.context.Ipos.Find(key);
            return ipodetail;
        }

        public IEnumerable<Stockprice> Search(DateTime from, DateTime to, Company company, StockExchange stockExchange)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stockprice> Search(DateTime from, DateTime to, Sector sector)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ipodetail entity)
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

