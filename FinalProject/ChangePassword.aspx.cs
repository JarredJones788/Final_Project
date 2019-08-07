// Author: Matt Ditmars
// Student ID: 991496942

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.lib;


namespace FinalProject
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        Account user;

        protected void Page_Load(object sender, EventArgs e)
        {
            Authenticate auth = new Authenticate();
            HttpCookie myCookie = Request.Cookies["token"];
            if (myCookie != null)
            {
                Account user = auth.checkSession(myCookie.Value.ToString());
                if(user != null)
                {
                    this.user = user;
                }
                
            }
            else
            {
                Response.Redirect("https://localhost:44309/Login");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                String password = txtConfirmPassword.Text;

                if (user.getPassword() != password)
                {
                    user.changePassword(password);
                    if (user.changePassword(password))
                    {
                        lblSubmit.Text = "Password changed successfully";
                        lblSubmit.ForeColor = System.Drawing.Color.Green;

                    }
                    else
                    {
                        lblSubmit.Text = "Error occurred";
                        lblSubmit.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblSubmit.Text = "Same as current password";
                }
                
            }
        }
    }
}