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



namespace StockMarket.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AccountsController : ControllerBase
    {

        private NewFolder1.IAccountRepository<Account> repository;
        public AccountsController(NewFolder1.IAccountRepository<Account> repository)
        {
            this.repository = repository;
        }
        private readonly IConfiguration configuration;
        public AccountsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("Login/{usertype}/{pwd}")]
        public IActionResult Validate(UserType usertype,string pwd)
        {
            if (usertype == UserType.Admin && pwd == "12345")
            {
                try
                {
                    return Ok(GenerateJwtToken(usertype));
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
                return StatusCode(500,"Invalid User");
        }
        private  Token GenerateJwtToken(UserType userType)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,userType.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,userType.ToString())
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var response = new Token
            {
                UserType=userType,
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }
    

        
        [HttpGet("logout")]
        public IActionResult Get()
        {
            repository.Logout();
            return Ok("logged out.");
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

/*
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
        */
    }
}







