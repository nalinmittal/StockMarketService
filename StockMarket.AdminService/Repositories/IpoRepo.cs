using Models;
using StockMarket.AdminService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public class IpoRepo : IRepo<Ipodetail>
    {

        private AdminContext context;

        public IpoRepo(AdminContext context)
        {
            this.context = context;
        }

        bool IRepo<Ipodetail>.Add(Ipodetail entity)
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

        IEnumerable<Ipodetail> IRepo<Ipodetail>.Get()
        {
            var ipos = this.context.Ipos;
            return ipos;
        }

        Ipodetail IRepo<Ipodetail>.Get(object key)
        {
            var ipo = this.context.Ipos.Find(key);
            return ipo;
        }

        IEnumerable<Ipodetail> IRepo<Ipodetail>.GetMatching(string name)
        {
            var ipos = this.context.Ipos.Where(c => c.Company.Companyname.Contains(name));
            return ipos;
        }
    }
}
