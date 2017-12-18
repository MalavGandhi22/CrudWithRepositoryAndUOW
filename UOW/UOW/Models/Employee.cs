using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UOW.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public byte IsActive { get; set; }
    }
}