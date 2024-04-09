using Connectivity.DAL.Helper;
using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

namespace project_vidhi.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public JsonResult Authenticate(String username, String password)
        {
            Session["Username"] = username;

            #region Not using from v1.2
            //if (username == "vidhi" && password == "vidhi1234")
            //{
            //    return Json(new { Success = true });
            //}
            //else if (username == "admin" && password == "admin")
            //    return Json(new { Success = true });
            //}
            //else
            //    return Json(new { Success = false }); 
            #endregion

      
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionPg"].ConnectionString;

            DataTable dt = new DataTable();
            try
            {
                string result = string.Empty;
                string error = string.Empty;

                dt = PostgreSQLHelper.GetProceduredata(connectionString, " ", "public.selectvidhi(username,password)", out result, out error, "'outjson'").Tables[0];

                //dt = PostgreSQLHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM public.\"Vidhi\" WHERE username = '"+ username + "' AND password = '"+ password + "'").Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Json(new { Success = true });
                }
                else
                {
                    return Json(new { Success = false });
                }
            }
            catch (Exception ex)
            {
                var error = ex.InnerException;
                var error1 = ex.StackTrace;
                return Json(new { Success = false });
            }
        }
        



    }
}
