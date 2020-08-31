using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using StockMarket.AccountService.Models;
using StockMarket.AccountService.NewFolder1;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.AccountService.Repositories
{
    public class AccountRepository : IAccountRepository<Account>
    {
        private AccountContext context;
        private IConfiguration configuration;

        public AccountRepository(AccountContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public Tuple<bool, string> Login(string username, string password)
        {
            try
            {
                Tuple<bool, string> result;
                var account = context.AccountUsers.FirstOrDefault(u => u.Username == username
                            && u.Password == password && u.Confirmed);
                if (account == null)
                {
                    result = new Tuple<bool, string>(false, "");
                }
                else
                {
                    var token = GenerateJwtToken(account);
                    result = new Tuple<bool, string>(true, token);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object GenerateJwtToken(object account)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(Account account)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, account.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, account.UserType.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration["JwtKey"]));
            var creds = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256);
            // recommednded is 5 mins
            var expires = DateTime.Now.AddDays(
                Convert.ToDouble(configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool Logout()
        {
            //cancel token

            return true;
        }

        public bool Signup(Account entity)
        {
            try
            {
                entity.Confirmed = true;
                context.AccountUsers.Add(entity);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
