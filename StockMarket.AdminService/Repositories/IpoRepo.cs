using Models;
using StockMarket.AdminService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public class IpoRepo : IRepo<IpoDetail>
    {

        private AdminContext context;

        public IpoRepo(AdminContext context)
        {
            this.context = context;
        }

        bool IRepo<IpoDetail>.Add(IpoDetail entity)
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

        IEnumerable<IpoDetail> IRepo<IpoDetail>.Get()
        {
            var ipos = this.context.Ipos;
            return ipos;
        }

        IpoDetail IRepo<IpoDetail>.Get(object key)
        {
            var ipo = this.context.Ipos.Find(key);
            return ipo;
        }

        IEnumerable<IpoDetail> IRepo<IpoDetail>.GetMatching(string name)
        {
            var ipos = this.context.Ipos.Where(c => c.Company.Companyname.Contains(name));
            return ipos;
        }
    }
}
