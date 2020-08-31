using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StockMarket.UserService.Repositories;

namespace StockMarket.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockpriceController : ControllerBase
    {
        private IRepository<Stockprice> repository;
        public StockpriceController(IRepository<Stockprice> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Stockprice> Get()
        {
            return repository.Get();
        }

        [HttpPost]
        public IActionResult Post([FromForm] Stockprice stockprice)
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
        public IActionResult Put(int id, [FromForm] Stockprice stockprice)
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
                return Ok("Stockprice deleted succesfully");
            }
            return StatusCode(500, "Internal Server Error");
        }

        [HttpGet("/api/students2/searchbycompany")]
        public IEnumerable<Stockprice> Get(DateTime from, DateTime to, Company company, StockExchange stockExchange)
        {
            return repository.Search(from, to, company, stockExchange);
        }

        [HttpGet("/api/students2/searchbysector")]
        public IEnumerable<Stockprice> Get(DateTime from, DateTime to, Sector sector)
        {
            return repository.Search(from, to, sector);
        }

    }
}
