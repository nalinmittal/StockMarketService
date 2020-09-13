using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using StockMarket.AdminService.Repositories;
using StockMarket.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyRepo<CompanyDto> repository;

        public CompanyController(ICompanyRepo<CompanyDto> repository)
        {
            this.repository = repository;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<CompanyDto> Get()
        {
            return this.repository.Get();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public CompanyDto Get(long id)
        {
            return this.repository.Get(id);
        }


        [HttpGet]
        [Route("/search/{name}")]
        public IEnumerable<CompanyDto> Get(string companyName)
        {
            return this.repository.GetMatching(companyName);
        }

        [HttpPost]
        public IActionResult Post([FromForm] CompanyDto company)
        {
            if(ModelState.IsValid)
            {
                var isAdded = this.repository.Add(company);
                if(isAdded)
                {
                    return Created("Company created.", company);
                }
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] CompanyDto company)
        {
            if(ModelState.IsValid)
            {
                if(id==company.Id)
                {
                    var existing = this.repository.Get(id);
                    if(existing==null)
                    {
                        return NotFound();
                    }

                    var isUpdated = this.repository.Update(company);
                    if(isUpdated)
                    {
                        return Ok(company);
                    }
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var company = this.repository.Get(id);
            if(company==null)
            {
                return NotFound();
            }
            var isDeleted = this.repository.Delete(id);
            if(isDeleted)
            {
                return Ok("Company deleted succesfully");
            }
            return StatusCode(500, "Internal Server Error");
        }
    }
}
