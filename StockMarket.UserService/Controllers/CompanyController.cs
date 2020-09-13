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
    public class CompanyController : ControllerBase
    {
        private IRepository<Company> repository;
        public CompanyController(IRepository<Company> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return repository.Get();
        }

        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return this.repository.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromForm] Company company)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(company);
                if (isAdded)
                {
                    return Created("company", company);
                }

            }

            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Company company)
        {
            if (ModelState.IsValid)
            {
                if (id == company.Id)
                {
                    var existing = this.repository.Get(id);
                    if (existing == null)
                    {
                        return NotFound();
                    }
                    var isUpdated = this.repository.Update(company);
                    if (isUpdated)
                    {
                        return Ok(company);
                    }
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = this.repository.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            var isDeleted = this.repository.Delete(company);
            if (isDeleted)
            {
                return Ok("Company deleted succesfully");
            }
            return StatusCode(500, "Internal Server Error");
        }


    }
}
