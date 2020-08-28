using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Username{ get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }
        public string Email { get; set; }
        public long Mobilenumber { get; set; }
        public bool Confirmed { get; set; }
    }
}
