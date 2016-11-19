using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExtreme_DemoApp.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalery { get; set; }
        public DateTime EmpDob { get; set; }
    }
}