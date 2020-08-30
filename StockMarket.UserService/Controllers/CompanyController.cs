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

       
    }
}
