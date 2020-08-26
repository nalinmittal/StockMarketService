using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Models
{
    class Stockprice
    {
        public string Companycode { get; set; }
        public string Stockexchange { get; set; }
        public float Currentprice { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

    }
}
