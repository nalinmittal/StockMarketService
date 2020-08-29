using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using StockMarket.AdminService.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        IRepo<Company> repository;

        public CompanyController(IRepo<Company> repository)
        {
            this.repository = repository;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return this.repository.Get();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return this.repository.Get(id);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
