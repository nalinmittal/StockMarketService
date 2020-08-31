using System;
using Microsoft.AspNetCore.Mvc;
using Models;
using StockMarket.AccountService.Models;
using StockMarket.AccountService.NewFolder1;

namespace StockMarket.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private IAccountRepository<Account> repository;
        public AccountsController(IAccountRepository<Account> repository)
        {
            this.repository = repository;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IActionResult Get(string username, string password)
        {
            //SSV
            if (!(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password)))
            {
                try
                {
                    var result = repository.Login(username, password);
                    // success -> token
                    if (result.Item1)
                    {
                        return Ok(result.Item2); //token
                    }
                    // fail -> 
                    // invalid credentials
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                catch (Exception ex) // internal server error
                {
                    return StatusCode(500, "internal server error");
                }
            }
            return BadRequest("Please pass both username and password");
        }

        // GET api/<AuthController>/5
        [HttpGet("logout")]
        public IActionResult Get()
        {
            repository.Logout();
            return Ok("logged out");
        }

        // POST api/<AuthController>
        // register new user / signup
        [HttpPost]
        public IActionResult Post([FromForm] Account account)
        {
            //SSV
            if (ModelState.IsValid)
            {
                //pass to repository
                var isSuccess = repository.Signup(account);
                if (isSuccess)
                {
                    return Ok("User registered successfully");
                }
                return StatusCode(500, "Internal server error");
            }
            return BadRequest(ModelState);
        }
    }
}








