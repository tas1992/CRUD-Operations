using form_simple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace form_simple.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       

        public IActionResult Index()
        {
            DataTable dt1 = new DataTable();
            using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
            {

                string cmd = "select id, name, age, gender, email from tbl_user";
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd, connection);
                da.Fill(dt1);
                connection.Close();
                // Do work here
            }
            List<Details> dtl11 = new List<Details>();

            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    Details details = new Details();
                    details.ID = Convert.ToInt32(dr["ID"]);
                    details.name = dr["name"].ToString();
                    details.age = Convert.ToInt32(dr["age"]);
                    details.gender = dr["gender"].ToString();
                    details.email = dr["email"].ToString();
                    dtl11.Add(details);
                }
            }
            ViewBag.details = dtl11;
            return View();
        }

        public ViewResult FillValues(int ID, string name, char age, string gender, string email)
        {
            Details dt = new Details();
            dt.name = name;
            dt.age = age;
            dt.email = email;
            dt.gender = gender;
            //using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
            //{

            //    SqlCommand cmd = new SqlCommand(string.Format("Select * from tbl_user where ID = {0}", ID), connection);
            //    connection.Open();
            //    SqlDataReader rd = cmd.ExecuteReader();
            //    if (rd.HasRows)
            //    {
            //        while (rd.Read())
            //        {
            //            dt.name = rd[1].ToString();
            //            dt.age = Convert.ToInt32(rd[2]);
            //            dt.gender = rd[3].ToString();
            //            dt.email = rd[4].ToString();

            //        }

            //    }
            //    connection.Close();
            //    // Do work here
            //}
            return View("Index", dt);
            // return null;
        }

        public ActionResult DeleteRecord(int id)
        {
            using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(string.Format("Delete from tbl_user where ID = {0}", id), connection);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult insertupdate(Details details)
        {
           
                if (details.ID == 0)
                {
                    using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
                    {
                        SqlCommand cmd = new SqlCommand(string.Format("Insert into tbl_user values ('{0}','{1}', '{2}', '{3}')", details.name, details.age, details.gender, details.email), connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // Do work here
                    }

                }
                else
                {
                    using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
                    {
                        SqlCommand cmd = new SqlCommand(string.Format("Update tbl_user set name='{0}',age='{1}',gender= '{2}', email='{3}' where ID={4}", details.name, details.age, details.gender, details.email, details.ID), connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        // Do work here
                    }


                }
            
            return RedirectToAction("Index");

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
