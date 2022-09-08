using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace AdoDotNet.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection(@"Data Source=AZAM-PC\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> listemp = new List<Models.EmployeeModel>();

            SqlCommand cmd = new SqlCommand("sp_Employee",con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpId = Convert.ToInt32(dr["EmpId"]);
                emp.EmpName = Convert.ToString(dr["EmpName"]);
                emp.EmpSalary = Convert.ToInt32(dr["EmpSalary"]);

                listemp.Add(emp);
            }
            return listemp;
        }
    }
}