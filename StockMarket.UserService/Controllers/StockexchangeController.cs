using System;
using System.Collections.Generic;
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
    public class StockexchangeController : ControllerBase
    {
        private IRepository<StockExchange> repository;

        public StockexchangeController(IRepository<StockExchange> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromForm] StockExchange stkexchange)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(stkexchange);
                if (isAdded)
                {
                    return Created("stockexchange", stkexchange);
                }

            }

            return BadRequest(ModelState);

        }

        [HttpGet]
        public IEnumerable<StockExchange> Get()
        {
            return repository.Get();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
