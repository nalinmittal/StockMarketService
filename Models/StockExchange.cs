using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class StockExchange
    {
        //public StockExchange()
        //{
        //    CompanyStockExchanges = new HashSet<CompanyStockExchange>();
        //}
        //[Key]
        public string Id { get; set; }
        [Required]
        public string Stockexchange { get; set; }
        [Required]
        public string Brief { get; set; }
        [Required]
        public string Contactaddress { get; set; }
        [Required]
        public string Remarks { get; set; }
        //public virtual ICollection<CompanyStockExchange> CompanyStockExchanges { get; set; }

    }
}
