using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Sectorname { get; set; }
        [Required]
        public string Brief { get; set; }
        public virtual ICollection<Company> Companylist { get; set; }
    }
}
