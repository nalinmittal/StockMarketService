using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        [ForeignKey("Company")]
        public virtual ICollection<Company> Companylist { get; set; }
    }
}
