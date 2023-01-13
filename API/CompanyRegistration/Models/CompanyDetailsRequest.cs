using System;

namespace CompanyRegistration.Models
{
    public class CompanyDetailsRequest
    {
        public int Id { get; set; }
        public int UserID { get; set; }       
        public string CompanyName{get; set;}
        public string CEO { get; set; }
        public Int64 Turnover { get; set; }
        public string Website { get; set; }
        public string Stock_Exchange { get; set; }
    }        
}
