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

        private tbl_userContext db = new tbl_userContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            List<TblUser> dt1 = db.TblUsers.ToList();
            //DataTable dt1 = new DataTable();
            //using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
            //{

            //    string cmd = "select id, name, age, gender, email from tbl_user";
            //    connection.Open();
            //    SqlDataAdapter da = new SqlDataAdapter(cmd, connection);
            //    da.Fill(dt1);
            //    connection.Close();
            //    // Do work here
            //}
            List<Details> dtl11 = new List<Details>();

            //if (dt1.Count() > 0)
            //{
            //    foreach (TblUser dr in dt1)
            //    {
            //        Details details = new Details();
            //        details.ID = Convert.ToInt32(dr["ID"]);
            //        details.name = dr["name"].ToString();
            //        details.age = Convert.ToInt32(dr["age"]);
            //        details.gender = dr["gender"].ToString();
            //        details.email = dr["email"].ToString();
            //        dtl11.Add(details);
            //    }
            //}
            ViewBag.details = dt1;
            return View();
        }

        public ViewResult FillValues(int ID, string name, string age, string gender, string email)
        {
            TblUser dt = new TblUser();
            dt.Name = name;
            dt.Age = age;
            dt.Email = email;
            dt.Gender = gender;
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
            using (tbl_userContext db = new tbl_userContext())
            {
                var result = db.TblUsers.Where(a => a.Id == id).FirstOrDefault();
                db.TblUsers.Remove(result);
                db.SaveChanges();
            }
            //using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
            //{
            //    SqlCommand cmd = new SqlCommand(string.Format("Delete from tbl_user where ID = {0}", id), connection);
            //    connection.Open();
            //    int result = cmd.ExecuteNonQuery();
            //    if (result > 0)
            //    {
            //    }
            //}
            return RedirectToAction("Index");
        }
        public ActionResult insertupdate(TblUser details)
        {

            if (details.Id == 0)
            {
                using (tbl_userContext tb = new tbl_userContext())
                {
                    tb.TblUsers.Add(details);
                    tb.SaveChanges();
                }
                //using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
                //{
                //    SqlCommand cmd = new SqlCommand(string.Format("Insert into tbl_user values ('{0}','{1}', '{2}', '{3}')", details.name, details.age, details.gender, details.email), connection);
                //    connection.Open();
                //    cmd.ExecuteNonQuery();
                //    connection.Close();
                //    // Do work here
                //}

            }
            else
            {
                using (tbl_userContext db = new tbl_userContext())
                {
                    db.TblUsers.Update(details);
                    db.SaveChanges();
                }
                //using (var connection = new SqlConnection("Data Source=IN-BAV-L0917;Initial Catalog=tbl_user;Integrated Security=True"))
                //{
                //    SqlCommand cmd = new SqlCommand(string.Format("Update tbl_user set name='{0}',age='{1}',gender= '{2}', email='{3}' where ID={4}", details.name, details.age, details.gender, details.email, details.ID), connection);
                //    connection.Open();
                //    cmd.ExecuteNonQuery();
                //    connection.Close();
                //    // Do work here
                //}


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
