using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public class StockExchangeRepo : IRepo<StockExchange>
    {
        private StockMarketContext context;

        public StockExchangeRepo(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(StockExchange entity)
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

        public bool Delete(StockExchange entity)
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

        public IEnumerable<StockExchange> Get()
        {
            var exchanges = this.context.StockExchanges;
            return exchanges;
        }

        public StockExchange Get(object key)
        {
            var exchange = this.context.StockExchanges.Find(key);
            return exchange;
        }

        public bool Update(StockExchange entity)
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
