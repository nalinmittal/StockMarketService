using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserService.Repositories
{
    public class StockpriceRepository : IRepository<Stockprice>
    {
        private StockMarketContext context;

        public StockpriceRepository(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(Stockprice entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Stockprice entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stockprice> Get()
        {
            throw new NotImplementedException();
        }

        public Stockprice Get(object key)
        {
            throw new NotImplementedException();
        }

        public bool Update(Stockprice entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stockprice> Search(DateTime from, DateTime to, Company company, StockExchange stockExchange)
        {
            var stockprices = context.Stockprices.Where(t => t.Stockexchange.Stockexchange==stockExchange.Stockexchange && t.Company.Companyname==company.Companyname && t.Timeoftransaction > from && t.Timeoftransaction < to);
            return stockprices;
        }

        public IEnumerable<Stockprice> Search(DateTime from, DateTime to, Sector sector)
        { 
            var stockprices = context.Stockprices.Where(t => t.Company.Sector.Sectorname == sector.Sectorname && t.Timeoftransaction > from && t.Timeoftransaction < to);
            return stockprices;
        }
    }
}
