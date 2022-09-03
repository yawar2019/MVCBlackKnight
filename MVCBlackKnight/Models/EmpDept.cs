using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlackKnight.Models
{
    public class EmpDept
    {
        public List<EmployeeModel> listEmp { get; set; }
        public List<DepartmentModel> listDept { get; set; }
    }
}