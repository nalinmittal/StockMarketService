using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StockMarket.Dtos;

namespace StockMarket.UserService.Repositories
{
    public interface IStockPriceRepository<T> : IRepository<T>
    {
        IEnumerable<T> Search(StockPriceDto stockpricedto);
    }
}

