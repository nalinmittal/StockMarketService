﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StockMarket.UserService.Repositories;
using StockMarket.Dtos;

namespace StockMarket.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPriceController : ControllerBase
    {
        private IStockPriceRepository<StockPrice> repository;
        public StockPriceController(IStockPriceRepository<StockPrice> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("{To}/{From}")]
        public int Get(int To, string From)
        {
            return To;
        }

        [HttpPost]
        public IActionResult Post([FromForm] StockPrice stockprice)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(stockprice);
                if (isAdded)
                {
                    return Created("stockprice", stockprice);
                }

            }

            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] StockPrice stockprice)
        {
            if (ModelState.IsValid)
            {
                if (id == stockprice.Id)
                {
                    var existing = this.repository.Get(id);
                    if (existing == null)
                    {
                        return NotFound();
                    }
                    var isUpdated = this.repository.Update(stockprice);
                    if (isUpdated)
                    {
                        return Ok(stockprice);
                    }
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var stockprice = this.repository.Get(id);
            if (stockprice == null)
            {
                return NotFound();
            }
            var isDeleted = this.repository.Delete(stockprice);
            if (isDeleted)
            {
                return Ok("StockPrice deleted succesfully");
            }
            return StatusCode(500, "Internal Server Error");
        }
        [HttpGet]
        [Route("chart/{To}/{From}/{CompanyId}/{StockExchangeId}")]
        public IEnumerable<StockPrice> Get( string To, string From, long CompanyId, string StockExchangeId)
        {
            StockPriceDto stockPriceDto = new StockPriceDto();
            stockPriceDto.To = To;
            stockPriceDto.From = From;
            stockPriceDto.StockExchangeId = StockExchangeId;
            stockPriceDto.CompanyId = CompanyId;

            return repository.Search(stockPriceDto);
        }

      
    }
}
