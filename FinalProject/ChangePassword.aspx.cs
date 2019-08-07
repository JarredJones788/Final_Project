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
            //authenticating user, if their session is not valid, redirect them to login page
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

        //method that changes the password of a user
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                String password = txtConfirmPassword.Text;

                //only update the password in the database if it is different then what is currently in the db
                if (user.getPassword() != password)
                {
                    user.changePassword(password);
                    //update the label to provide some insight to the user if their action was succesful or not
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
