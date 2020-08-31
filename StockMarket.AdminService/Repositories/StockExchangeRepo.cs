using Microsoft.EntityFrameworkCore;
using Models;
using StockMarket.AdminService.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket.AdminService.Repositories
{
    public class StockExchangeRepo : IRepo<StockExchange>
    {
        private AdminContext context;

        public StockExchangeRepo(AdminContext context)
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

        //public bool Delete(StockExchange entity)
        //{
        //    try
        //    {
        //        this.context.Remove(entity);
        //        int updates = context.SaveChanges();
        //        if (updates > 0)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

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

        //public bool Update(StockExchange entity)
        //{
        //    try
        //    {
        //        this.context.Entry(entity).State = EntityState.Modified;
        //        int updates = context.SaveChanges();
        //        if (updates > 0)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        IEnumerable<StockExchange> IRepo<StockExchange>.GetMatching(string name)
        {
            var exchanges = this.context.StockExchanges.Where(c => c.Stockexchange.Contains(name));
            return exchanges;
        }
    }
}
