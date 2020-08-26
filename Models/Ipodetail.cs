using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Models
{
    class Ipodetail
    {
        public int Id { get; set; }
        public string Companyname { get; set; }
        public int Stockexchange { get; set; }
        public float Pricepershare { get; set; }
        public int Totalnumberofshares { get; set; }
        public string Opendatetime { get; set; }
        public string Remarks { get; set; }
    }
}
