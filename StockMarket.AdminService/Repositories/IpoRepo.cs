using Models;
using StockMarket.AdminService.Data;
using StockMarket.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public class IpoRepo : IRepo<IpoDetailDto>
    {

        private AdminContext context;

        public IpoRepo(AdminContext context)
        {
            this.context = context;
        }

        bool IRepo<IpoDetailDto>.Add(IpoDetailDto entity)
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

        IEnumerable<IpoDetailDto> IRepo<IpoDetailDto>.Get()
        {
            var ipos = this.context.Ipos;
            return ipos;
        }

        IpoDetail IRepo<IpoDetailDto>.Get(object key)
        {
            var ipo = this.context.Ipos.Find(key);
            return ipo;
        }

        IEnumerable<IpoDetailDto> IRepo<IpoDetailDto>.GetMatching(string name)
        {
            var ipos = this.context.Ipos.Where(c => c.Company.Companyname.Contains(name));
            return ipos;
        }
    }
}
