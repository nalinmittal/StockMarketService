using Microsoft.EntityFrameworkCore;
using Models;
using StockMarket.AdminService.Data;
using StockMarket.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket.AdminService.Repositories
{
    public class StockExchangeRepo : IRepo<StockExchangeDto>
    {
        private AdminContext context;

        public StockExchangeRepo(AdminContext context)
        {
            this.context = context;
        }
        public bool Add(StockExchangeDto entity)
        {
            try
            {
                var exchange = new StockExchange
                {
                    Id = entity.Id,
                    //Stockexchange = entity.Stockexchange,
                    Brief = entity.Brief,
                    Remarks = entity.Remarks,
                    Contactaddress = entity.Contactaddress,
                    //CompanyStockExchanges = new List<CompanyStockExchange>()
                };
                //foreach (var companyId in entity.CompanyIds)
                //{
                //    exchange.CompanyStockExchanges.Add(this.context.CompanyStockExchanges.Find(companyId, exchange.Id));
                //}
                context.Add(exchange);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<StockExchangeDto> Get()
        {
            var exchanges = new List<StockExchangeDto>();
            foreach (var exchange in this.context.StockExchanges)
            {
                StockExchangeDto exchangeDto = new StockExchangeDto
                {
                    Id = exchange.Id,
                    //Stockexchange = exchange.Stockexchange,
                    Brief = exchange.Brief,
                    Remarks = exchange.Remarks,
                    Contactaddress = exchange.Contactaddress,
                    CompanyIds = new List<long>()
                };
                foreach (var companyStockExchange in context.CompanyStockExchanges.Where(c=>c.StockExchangeId==exchange.Id))
                {
                    exchangeDto.CompanyIds.Add(companyStockExchange.CompanyId);
                }
                exchanges.Add(exchangeDto);
            }
            return exchanges;
        }

        public StockExchangeDto Get(object key)
        {
            var exchange = this.context.StockExchanges.Find(key);
            StockExchangeDto exchangeDto = new StockExchangeDto
            {
                Id = exchange.Id,
                //Stockexchange = exchange.Stockexchange,
                Brief = exchange.Brief,
                Remarks = exchange.Remarks,
                Contactaddress = exchange.Contactaddress,
                CompanyIds = new List<long>()
            };
            foreach (var companyStockExchange in context.CompanyStockExchanges.Where(c => c.StockExchangeId == exchange.Id))
            {
                exchangeDto.CompanyIds.Add(companyStockExchange.CompanyId);
            }
            return exchangeDto;
        }

        //public bool Update(StockExchange entity)
        //{
        //    try
        //    {
        //        this.context.Entry(entity).State = EntityState.Modified;
        //        int updates = context.SaveChanges();
        //        if (updates > 0)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        IEnumerable<StockExchangeDto> IRepo<StockExchangeDto>.GetMatching(string name)
        {

            var exchanges = this.context.StockExchanges.Where(e => e.Id.Contains(name));
            List<StockExchangeDto> exchangeDtos = new List<StockExchangeDto>();
            foreach (var exchange in exchanges)
            {
                StockExchangeDto exchangeDto = new StockExchangeDto
                {
                    Id = exchange.Id,
                    //Stockexchange = exchange.Stockexchange,
                    Brief = exchange.Brief,
                    Remarks = exchange.Remarks,
                    Contactaddress = exchange.Contactaddress,
                    CompanyIds = new List<long>()
                };
                foreach (var companyStockExchange in context.CompanyStockExchanges.Where(c => c.StockExchangeId == exchange.Id))
                {
                    exchangeDto.CompanyIds.Add(companyStockExchange.CompanyId);
                }
                exchangeDtos.Add(exchangeDto);
            }
            return exchangeDtos;
        }
    }
}
