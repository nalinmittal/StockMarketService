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
            var stockprices = context.Stockprices.Where(t => t.Stockexchange.Stockexchange==stockExchange.Stockexchange && t.Company.Companyname==company.Companyname && t.TimeOfTransaction > from && t.TimeOfTransaction < to);
            return stockprices;
        }

        public IEnumerable<StockPrice> Search(DateTime from, DateTime to, Sector sector)
        { 
            var stockprices = context.Stockprices.Where(t => t.Company.Sector.Sectorname == sector.Sectorname && t.TimeOfTransaction > from && t.TimeOfTransaction < to);
            return stockprices;
        }
    }
}
