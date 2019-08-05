using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Login : System.Web.UI.Page
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
                    Response.Redirect("https://localhost:44309/Home");
                }
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            Authenticate auth = new Authenticate();
            Account user = auth.login(username.Text, password.Text);
            if (user != null)
            {
                auth.setClientToken(Response, user.getToken());
                Response.Redirect("https://localhost:44309/Home");
            }
            else
            {
                status.Text = "Invalid Login";
                status.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44309/Register");
        }
    }

}