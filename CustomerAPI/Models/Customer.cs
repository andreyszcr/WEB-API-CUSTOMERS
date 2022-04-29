using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerAPI.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string nameCustomer { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string notes { get; set; }
    }
}