using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public interface ICompanyRepo<T> : IRepo<T>
    {
        bool Update(T entity);
        bool Delete(long key);
    }
}
