using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class User
    {
        public int Id { get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }
        public string Email { get; set; }
        public int Mobilenumber { get; set; }
        public string Confirmed { get; set; }
    }
}
