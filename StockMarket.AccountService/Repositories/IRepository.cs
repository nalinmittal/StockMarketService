using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StockMarket.AccountService.NewFolder1
{
    public interface IRepository<T>
    {
        bool Signup(T entity);
        Tuple<bool, TokenDetails> Login(string username, string password);
        bool Logout();

        bool UpdateProfile(T entity);
        T GetProfile(ClaimsPrincipal currentUser);
    }
}
