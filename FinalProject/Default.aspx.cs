using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using FinalProject.lib;


namespace FinalProject
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Authenticate auth = new Authenticate();
            HttpCookie myCookie = Request.Cookies["token"];
            if (myCookie != null)
            {
                Account user = auth.checkSession(myCookie.Value.ToString());
                if (user != null)
                {
                    Debug.WriteLine(user.GetType());
                    Debug.WriteLine("User has a valid session");
                }
                else
                {
                    Response.Redirect("https://localhost:44309/Login");
                    Debug.WriteLine("No session Found");
                }
            }
            else
            {
                Response.Redirect("https://localhost:44309/Login");
                Debug.WriteLine("No session Found");
            }
        }

    }
}