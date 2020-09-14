using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Models;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [StringLength(30)]
        public UserType UserType { get; set; }
        [StringLength(30)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(30)]
        public long Mobile { get; set; }
        public bool Confirmed { get; set; }
    }
}