using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRegistration.Data
{
    public class CompanyDetails
    {
        [Key]
       public int Id { get; set; }
       
        public int UserID { get; set; }

        public string CompanyName { get; set; }

        public string CEO { get; set; }

        public Int64 Turnover { get; set; }

        public string Website { get; set; }

        public string Stock_Exchange { get; set; }
    }
}
