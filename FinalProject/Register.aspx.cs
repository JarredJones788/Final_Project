﻿// Author: Jarred Jones-Schack
// Student ID: 991506579

using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Register : System.Web.UI.Page
    {

        //Checks user session when page loads.
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

        //Registers a new account for the user. Checks if username is already taken.
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {


            String user = username.Text;
            String pass = password.Text;
            int type = accountType.SelectedIndex;
            String name = fullName.Text;
            String cellPhone = phone.Text;
            String userEmail = email.Text;
            String userCompany = company.Text;

            Account acc = new Account("", user, pass, type, name, cellPhone, userEmail, userCompany, "", "");
            int resStatus = acc.createAccount();

            if (resStatus == 0)
            {
                Response.Redirect("https://localhost:44309/Login");
            }
            else if (resStatus == 1)
            {
                status.Text = "Username is taken!";
                status.ForeColor = System.Drawing.Color.Red;
            }
            else if (resStatus == 2)
            {
                status.Text = "Error Creating Account!";
            }
        }

    }
}