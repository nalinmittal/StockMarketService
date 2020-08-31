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
    public class IpodetailController : ControllerBase
    {
        private IRepository<Ipodetail> repository;
        public IpodetailController(IRepository<Ipodetail> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Ipodetail> Get()
        {
            return repository.Get();
        }

        [HttpPost]
        public IActionResult Post([FromForm] Ipodetail ipodetail)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(ipodetail);
                if (isAdded)
                {
                    return Created("ipodetail", ipodetail);
                }

            }

            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Ipodetail ipodetail)
        {
            if (ModelState.IsValid)
            {
                if (id == ipodetail.Id)
                {
                    var existing = this.repository.Get(id);
                    if (existing == null)
                    {
                        return NotFound();
                    }
                    var isUpdated = this.repository.Update(ipodetail);
                    if (isUpdated)
                    {
                        return Ok(ipodetail);
                    }
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ipodetail = this.repository.Get(id);
            if (ipodetail == null)
            {
                return NotFound();
            }
            var isDeleted = this.repository.Delete(ipodetail);
            if (isDeleted)
            {
                return Ok("Company deleted succesfully");
            }
            return StatusCode(500, "Internal Server Error");
        }


    }
}
