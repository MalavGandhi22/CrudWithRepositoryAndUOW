using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UOW.Models;

namespace UOW
{
    public class EmployeeContaxt :DbContext
    {
        public EmployeeContaxt()
            : base("name=DbConnectionString")
        {
        }

        public DbSet<Employee> Employees { get; set; } 
    }
}