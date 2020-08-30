using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserService.Repositories
{
    public class StockexchangeRepository : IRepository<StockExchange>
    {
        private StockMarketContext context;

        public StockexchangeRepository(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(StockExchange entity)
        {
            try
            {
                //insert 
                context.StockExchanges.Add(entity);
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
            throw new NotImplementedException();
        }

        public IEnumerable<StockExchange> Get()
        {
            var stockexchanges = context.StockExchanges;
            return stockexchanges;
        }

        public StockExchange Get(object key)
        {
            throw new NotImplementedException();
        }

        public bool Update(StockExchange entity)
        {
            throw new NotImplementedException();
        }
    }
}
