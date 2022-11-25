using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deepak_DotNetTask.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Deepak_DotNetTask.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(string empsearch)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);
            string sqlquery = "select * from Employees where EmpName like '%" + empsearch + "%'";
            SqlCommand sqlCom = new SqlCommand(sqlquery,sqlcon);
            sqlcon.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            List<EmpClass> ec = new List<EmpClass>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ec.Add(new EmpClass
                {
                    EmpCode = Convert.ToInt32(dr["EmpCode"]),
                    EmpName = Convert.ToString(dr["EmpName"]),
                    Dob = Convert.ToDateTime(dr["Dob"]),
                    Doj = Convert.ToDateTime(dr["Doj"]),
                    Department = Convert.ToString(dr["Department"]),
                    ContactNo = Convert.ToInt32(dr["ContactNo"]),
                    ResignedDate = Convert.ToDateTime(dr["ResignedDate"]),
                    ReportTo = Convert.ToString(dr["ReportTo"])

                });
            }
            sqlcon.Close();
            ModelState.Clear();
            return View(ec);
        }
    }
}