using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Diagnostics;
using FinalProject.lib;
using System.IO;

namespace FinalProject
{
    public partial class _Default : Page
    {

        Account user;

        protected void Page_Load(object sender, EventArgs e)
        {
            Authenticate auth = new Authenticate();
            HttpCookie myCookie = Request.Cookies["token"];
            if (myCookie != null)
            {
                Account user = auth.checkSession(myCookie.Value.ToString());
                if (user != null)
                {
                    this.user = user;
                    profilePic.ImageUrl = "/Uploads/"+user.getPicture()+".png";
                    profilePic.Width = 100;
                    profilePic.Height = 100;
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

        protected void ButtonUpdateInfo_Click(object sender, EventArgs e)
        {
            if (user != null)
            {

                //Update Password
                String password = "555";

                if (user.getPassword() != password)
                {
                    user.changePassword(password);
                }


                //Update Contact Info
                String name = "Tommy123";
                String phone = "123-123-1233";
                String email = "123@hotmail.com";
                String company = "123 Inc";

                if (name != user.getName())
                {
                    user.setName(name);
                }
                if (phone != user.getPhone())
                {
                    user.setPhone(phone);
                }
                if (email != user.getEmail())
                {
                    user.setEmail(email);
                }
                if (name != user.getCompany())
                {
                    user.setCompany(company);
                }

                user.changeAccountInfo();
            }
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                String fileId = user.uploadProfileImage();
                if (fileId != "error")
                {
                    //Deletes old file
                    if (user.getPicture() != "" || user.getPicture() != null)
                    {
                        String deletePath = Path.Combine(Server.MapPath("~/Uploads"), user.getPicture() + ".png");
                        File.Delete(deletePath);
                    }

                    //Saves new file
                    String uploadPath = Path.Combine(Server.MapPath("~/Uploads"), fileId + ".png"); //Path.GetExtension(FileUpload.FileName)
                    FileUpload.PostedFile.SaveAs(uploadPath);
                    profilePic.ImageUrl = "/Uploads/" + fileId + ".png";
                    profilePic.Width = 100;
                    profilePic.Height = 100;
                }
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            String username = "billy";
            String password = "123";
            int type = 1;
            String name = "Billy";
            String phone = "647-343-2342";
            String email = "Bill@billy.com";
            String company = "Billy Inc";

            Account billy = new Account("", username, password, type, name, phone, email, company, "", ""); //Blank fields will be autofilled or not needed.
            billy.createAccount();
        }
    }
}