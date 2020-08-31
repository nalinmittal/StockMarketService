using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace StockMarket.UserService.Repositories
{
    public interface IStockPriceRepository<T> : IRepository<T>
    {
        IEnumerable<T> Search(DateTime from, DateTime to, Company company, StockExchange stockExchange);
        IEnumerable<T> Search(DateTime from, DateTime to, Sector sector);
    }
}

