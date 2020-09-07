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

        public bool Add(IpoDetailDto entity)
        {
            try
            {
                var ipo = new IpoDetail
                {
                    //Id = entity.Id,
                    Pricepershare = entity.Pricepershare,
                    Totalnumberofshares = entity.Totalnumberofshares,
                    Remarks = entity.Remarks,
                    Opendatetime = entity.Opendatetime,
                    CompanyId = entity.CompanyId,
                    StockExchangeId = entity.StockExchangeId
                    //CompanyStockExchange = this.context.CompanyStockExchanges.Find(entity.CompanyId,entity.StockExchangeId)
                };
                this.context.Add(ipo);
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

        public IEnumerable<IpoDetailDto> Get()
        {
            var ipos = new List<IpoDetailDto>();
            foreach (var ipo in this.context.Ipos)
            {
                IpoDetailDto ipoDto = new IpoDetailDto
                {
                    Id = ipo.Id,
                    Pricepershare = ipo.Pricepershare,
                    Totalnumberofshares = ipo.Totalnumberofshares,
                    Remarks = ipo.Remarks,
                    Opendatetime = ipo.Opendatetime,
                    CompanyId = ipo.CompanyId,
                    StockExchangeId = ipo.StockExchangeId
                };
                ipos.Add(ipoDto);
            }
            return ipos;
        }

        public IpoDetailDto Get(object key)
        {
            var ipo = this.context.Ipos.Find(key);
            IpoDetailDto ipoDto = new IpoDetailDto
            {
                Id = ipo.Id,
                Pricepershare = ipo.Pricepershare,
                Totalnumberofshares = ipo.Totalnumberofshares,
                Remarks = ipo.Remarks,
                Opendatetime = ipo.Opendatetime,
                CompanyId = ipo.CompanyId,
                StockExchangeId = ipo.StockExchangeId
            };
            return ipoDto;
        }

        IEnumerable<IpoDetailDto> IRepo<IpoDetailDto>.GetMatching(string name)
        {
            var companies = context.Companies.Where(c => c.Companyname.Contains(name));
            List<IpoDetailDto> ipoDtos = new List<IpoDetailDto>();
            foreach (var company in companies)
            {
                var ipo = context.Ipos.Where(i => i.CompanyId == company.Id).ToList()[0];
                IpoDetailDto ipoDto = new IpoDetailDto
                {
                    Id = ipo.Id,
                    Pricepershare = ipo.Pricepershare,
                    Totalnumberofshares = ipo.Totalnumberofshares,
                    Remarks = ipo.Remarks,
                    Opendatetime = ipo.Opendatetime,
                    CompanyId = ipo.CompanyId,
                    StockExchangeId = ipo.StockExchangeId
                };
                ipoDtos.Add(ipoDto);
            }
            return ipoDtos;
        }
    }
}
