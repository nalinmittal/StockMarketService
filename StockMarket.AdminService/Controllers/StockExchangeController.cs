using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using StockMarket.AdminService.Repositories;
using StockMarket.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        IRepo<StockExchangeDto> repository;

        public StockExchangeController(IRepo<StockExchangeDto> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<StockExchangeDto> Get()
        {
            return this.repository.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public StockExchangeDto Get(string id)
        {
            return this.repository.Get(id);
        }

        [HttpGet]
        [Route("names")]
        public IEnumerable<string> GetNamesController()
        {
            return this.repository.GetNames();
        }

        //[HttpGet]
        //[Route("/search/{name}")]
        //public IEnumerable<StockExchangeDto> Get(string exchangeName)
        //{
        //    return this.repository.GetMatching(exchangeName);
        //}

        [HttpPost]
        public IActionResult Post([FromForm] StockExchangeDto exchange)
        {
            if (ModelState.IsValid)
            {
                var isAdded = this.repository.Add(exchange);
                if (isAdded)
                {
                    return Created("Stock Exchange added.", exchange);
                }
            }
            return BadRequest(ModelState);
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromForm] StockExchange exchange)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (id == exchange.Id)
        //        {
        //            var existing = this.repository.Get(id);
        //            if (existing == null)
        //            {
        //                return NotFound();
        //            }

        //            var isUpdated = this.repository.Update(exchange);
        //            if (isUpdated)
        //            {
        //                return Ok(exchange);
        //            }
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        // DELETE api/<CompanyController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var exchange = this.repository.Get(id);
        //    if (exchange == null)
        //    {
        //        return NotFound();
        //    }
        //    var isDeleted = this.repository.Delete(exchange);
        //    if (isDeleted)
        //    {
        //        return Ok("Stock Exchange deleted succesfully");
        //    }
        //    return StatusCode(500, "Internal Server Error");
        //}
    }
}
