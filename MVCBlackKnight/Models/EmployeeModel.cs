using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlackKnight.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        [ScaffoldColumn(false)]
        public int EmpSalary { get; set; }
        public bool status { get; set; }
    }
}