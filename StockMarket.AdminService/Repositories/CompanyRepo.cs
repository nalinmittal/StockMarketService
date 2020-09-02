using Microsoft.EntityFrameworkCore;
using Models;
using StockMarket.AdminService.Data;
using StockMarket.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public class CompanyRepo : ICompanyRepo<CompanyDto>
    {
        private AdminContext context;

        public CompanyRepo(AdminContext context)
        {
            this.context = context;
        }

        public bool Add(CompanyDto entity)
        {
            try
            {
                var company = new Company
                {
                    Id = entity.Id,
                    Companyname = entity.Companyname,
                    Turnover = entity.Turnover,
                    Ceo = entity.Ceo,
                    Boardofdirectors = entity.Boardofdirectors,
                    Brief = entity.Brief,
                    CompanyStockExchanges = new List<CompanyStockExchange>()
                };
                foreach (var exchangeId in entity.StockExchangeIds)
                {
                    company.CompanyStockExchanges.Add(this.context.CompanyStockExchanges.Find(company.Id, exchangeId));
                }
                this.context.Add(company);
                int updates = context.SaveChanges();
                if(updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Delete(CompanyDto entity)
        {
            try
            {
                var company = new Company
                {
                    Id = entity.Id,
                    Companyname = entity.Companyname,
                    Turnover = entity.Turnover,
                    Ceo = entity.Ceo,
                    Boardofdirectors = entity.Boardofdirectors,
                    Brief = entity.Brief,
                    CompanyStockExchanges = new List<CompanyStockExchange>()
                };
                foreach (var exchangeId in entity.StockExchangeIds)
                {
                    company.CompanyStockExchanges.Add(this.context.CompanyStockExchanges.Find(company.Id, exchangeId));
                }
                this.context.Remove(company);
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

        public IEnumerable<CompanyDto> Get()
        {
            var companies = new List<CompanyDto>();
            foreach (var company in this.context.Companies)
            {
                CompanyDto companyDto = new CompanyDto
                {
                    Id = company.Id,
                    Companyname = company.Companyname,
                    Turnover = company.Turnover,
                    Ceo = company.Ceo,
                    Boardofdirectors = company.Boardofdirectors,
                    Brief = company.Brief,
                    StockExchangeIds = new List<long>()
                };
                foreach(var companystockexchange in company.CompanyStockExchanges)
                {
                    companyDto.StockExchangeIds.Add(companystockexchange.StockExchangeId);
                }
                companies.Add(companyDto);
            }
            return companies;
        }

        public CompanyDto Get(object key)
        {
            var company = this.context.Companies.Find(key);
            CompanyDto companyDto = new CompanyDto
            {
                Id = company.Id,
                Companyname = company.Companyname,
                Turnover = company.Turnover,
                Ceo = company.Ceo,
                Boardofdirectors = company.Boardofdirectors,
                Brief = company.Brief,
                StockExchangeIds = new List<long>()
            };
            foreach (var companystockexchange in company.CompanyStockExchanges)
            {
                companyDto.StockExchangeIds.Add(companystockexchange.StockExchangeId);
            }
            return companyDto;
        }

        public IEnumerable<CompanyDto> GetMatching(string name)
        {
            var companies = this.context.Companies.Where(c => c.Companyname.Contains(name));
            List<CompanyDto> companyDtos = new List<CompanyDto>();           
            foreach (var company in companies)
            {
                CompanyDto companyDto = new CompanyDto
                {
                    Id = company.Id,
                    Companyname = company.Companyname,
                    Turnover = company.Turnover,
                    Ceo = company.Ceo,
                    Boardofdirectors = company.Boardofdirectors,
                    Brief = company.Brief,
                    StockExchangeIds = new List<long>()
                };
                foreach (var companystockexchange in company.CompanyStockExchanges)
                {
                    companyDto.StockExchangeIds.Add(companystockexchange.StockExchangeId);
                }
                companyDtos.Add(companyDto);
            }
            return companyDtos;
        }

        public bool Update(CompanyDto entity)
        {
            try
            {
                this.context.Entry(entity).State = EntityState.Modified;
                int updates = context.SaveChanges();
                if(updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
