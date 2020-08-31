using Microsoft.VisualBasic.CompilerServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public interface IRepo<T>
    {
        bool Add(T entity);
        IEnumerable<T> Get();
        T Get(object key);
        IEnumerable<T> GetMatching(string name);
    }
}
