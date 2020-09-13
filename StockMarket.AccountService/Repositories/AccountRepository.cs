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
    public class AccountRepository : IRepository<User>
    {
        private AccountContext context;
        private IConfiguration configuration;

        public AccountRepository(AccountContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }


        public Tuple<bool, TokenDetails> Login(string username, string password)
        {
            try
            {
                Tuple<bool, TokenDetails> result;
                var user = context.Users.FirstOrDefault(u => u.Username == username
                            && u.Password == password && u.Confirmed);
                if (user == null)
                {
                    result = new Tuple<bool, TokenDetails>(false, null);
                }
                else
                {
                    var token = GenerateJwtToken(user);
                    var temp = new TokenDetails(token, (int)user.UserType);
                    result = new Tuple<bool, TokenDetails>(true, temp);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.UserType.ToString())
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
            return true;
        }

        public bool Signup(User entity)
        {
            try
            {
                entity.Confirmed = true;
                context.Users.Add(entity);
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


        public bool UpdateProfile(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetProfile(ClaimsPrincipal currentUser)
        {
            var email = currentUser.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
            return context.Users.FirstOrDefault(u => u.Email == email);

        }
    }
}
