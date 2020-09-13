using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using NuGet.Protocol.Core.Types;
using StockMarket.AccountService.Models;
using StockMarket.AccountService.NewFolder1;

namespace StockMarket.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IRepository<User> repository;

        public AccountController(IRepository<User> repository)
        {
            this.repository = repository;
        }

        [HttpPost("login")]
        public IActionResult Post(LoginData item)
        {
            //SSV
            if (!(string.IsNullOrEmpty(item.userName) && string.IsNullOrEmpty(item.password)))
            {
                try
                {
                    var result = repository.Login(item.userName, item.password);
                    return Ok(result.Item2);
                }
                catch (Exception ex) // internal server error
                {
                    return StatusCode(500, "internal server error");
                }
            }
            return BadRequest("Please pass both username and password");
        }

        // GET api/<AccountController>/5
        [HttpGet("logout")]
        public IActionResult Get()
        {
            repository.Logout();
            return Ok("logged out");
        }

        // POST api/<AccountController>
        // register new user / signup
        [HttpPost]
        public IActionResult Post([FromForm] User user)
        {
            //SSV
            if (ModelState.IsValid)
            {
                //pass to repository
                var isSuccess = repository.Signup(user);
                if (isSuccess)
                {
                    return Ok("User registered successfully");
                }
                return StatusCode(500, "Internal server error");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("profile")]
        [Authorize]
        public IActionResult GetProfile()
        {
            var currentUser = HttpContext.User;
            var result = repository.GetProfile(currentUser);

            return Ok(result);
        }
    }
}
