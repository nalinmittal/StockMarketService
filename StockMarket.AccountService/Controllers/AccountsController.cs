using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using StockMarket.AccountService.Models;



namespace StockMarket.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private NewFolder1.IAccountRepository<Account> repository;
        public AccountsController(NewFolder1.IAccountRepository<Account> repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public IActionResult Get(string username, string password)
        {

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
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "internal server error");
                }
            }
            return BadRequest("Please pass both username and password");
        }

        [HttpGet("logout")]
        public IActionResult Get()
        {
            repository.Logout();
            return Ok("logged out");
        }


        [HttpPost]
        public IActionResult Post([FromForm] Account account)
        {

            if (ModelState.IsValid)
            {
                var isSuccess = repository.Signup(account);
                if (isSuccess)
                {
                    return Ok("User registered successfully");
                }
                return StatusCode(500, "Internal server error.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("profile")]
        [Authorize]
        public IActionResult GetProfile()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
            var result = repository.GetProfile(email);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateProfile([FromForm] Account account)
        {
            var isSuccess = repository.UpdateProfile(account);
            if (isSuccess)
            {
                return Ok("Updated changes successfully");
            }
            return StatusCode(500, "Internal server error");

        }

    }
}







