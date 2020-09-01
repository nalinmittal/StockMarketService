using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.UserService.Data;

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
            throw new NotImplementedException();
        }

        public bool Delete(StockPrice entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockPrice> Get()
        {
            throw new NotImplementedException();
        }

        public StockPrice Get(object key)
        {
            throw new NotImplementedException();
        }

        public bool Update(StockPrice entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockPrice> Search(DateTime from, DateTime to, Company company, StockExchange stockExchange)
        {
            var stockPrices = context.StockPrices.Where(s =>

                 s.CompanyStockExchange.CompanyId == company.Id &&

                 s.CompanyStockExchange.StockExchangeId == stockExchange.Id &&

                 Convert.ToDateTime(s.Date + ' ' + s.Time) >= from &&

                 Convert.ToDateTime(s.Date + ' ' + s.Time) <= to);
            return stockPrices;
        }

        public IEnumerable<StockPrice> Search(DateTime from, DateTime to, Sector sector)
        { 
            var stockprices = context.StockPrices.Where(t => t.Company.Sector.Sectorname == sector.Sectorname);
            return stockprices;
        }
    }
}
