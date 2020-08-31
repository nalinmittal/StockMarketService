using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.UserService.Data;

namespace StockMarket.UserService.Repositories
{
    public class IpoDetailRepository : IRepository<IpoDetail>

    {
        private StockMarketContext context;

        public IpoDetailRepository(StockMarketContext context)
        {
            this.context = context;
        }

        public bool Add(IpoDetail entity)
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

        public bool Delete(IpoDetail entity)
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

        public IEnumerable<IpoDetail> Get()
        {
            var ipodetails = this.context.Ipos;
            return ipodetails;
        }

        public IpoDetail Get(object key)
        {
            var ipodetail = this.context.Ipos.Find(key);
            return ipodetail;
        }

        public bool Update(IpoDetail entity)
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

