using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class TokenDetails
    {
        public TokenDetails(string token, int user)
        {
            this.token = token;
            usertype = user;
        }

        public int usertype { get; set; }

        public string token { get; set; }

    }
}