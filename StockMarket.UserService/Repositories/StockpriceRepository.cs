using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.UserService.Data;
using Microsoft.EntityFrameworkCore;
using StockMarket.Dtos;

namespace StockMarket.UserService.Repositories
{
    public class StockPriceRepository : IStockPriceRepository<StockPrice>
    {
        private StockMarketContext context;

        public StockPriceRepository(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(StockPrice entity)
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

        public bool Delete(StockPrice entity)
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

        public IEnumerable<StockPrice> Get()
        {
            var stockPrices = this.context.StockPrices;
            return stockPrices;
        }

        public StockPrice Get(object key)
        {
            var stockPrice = this.context.StockPrices.Find(key);
            return stockPrice;
        }

        public bool Update(StockPrice entity)
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

        public IEnumerable<StockPrice> Search(StockPriceDto stockpricedto)
        {
            var stockPrices = context.StockPrices.Where(s =>

                 s.CompanyStockExchange.CompanyId == stockpricedto.CompanyId &&

                 s.CompanyStockExchange.StockExchangeId == stockpricedto.StockExchangeId &&

                 Convert.ToDateTime(s.Date + ' ' + s.Time) >= stockpricedto.from &&

                 Convert.ToDateTime(s.Date + ' ' + s.Time) <= stockpricedto.to);
            return stockPrices;
        }
        public IEnumerable<StockPrice> Search(DateTime from, DateTime to, Sector sector)
        {
            //var stockprices = context.StockPrices.Where(t => t.Company.Sector.Sectorname == sector.Sectorname);
            //return stockprices;
            throw new NotImplementedException();
        }

    }
}
