using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using StockMarket.AdminService.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpoController : ControllerBase
    {
        IRepo<Ipodetail> repository;

        public IpoController(IRepo<Ipodetail> repository)
        {
            this.repository = repository;
        }

        // GET: api/<IpoController>
        [HttpGet]
        public IEnumerable<Ipodetail> Get()
        {
            return this.repository.Get();
        }

        // GET api/<IpoController>/5
        [HttpGet("{id}")]
        public Ipodetail Get(int id)
        {
            return this.repository.Get(id);
        }

        [HttpGet("{name}")]
        public IEnumerable<Ipodetail> Get(string companyName)
        {
            return this.repository.GetMatching(companyName);
        }

        // POST api/<IpoController>
        [HttpPost]
        public IActionResult Post([FromForm] Ipodetail ipo)
        {
            if (ModelState.IsValid)
            {
                var isAdded = this.repository.Add(ipo);
                if (isAdded)
                {
                    return Created("IPO details added.", ipo);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
