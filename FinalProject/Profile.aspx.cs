// Author: Matt Ditmars
// Student ID: 991496942

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.lib;
using System.Diagnostics;
using System.IO;

namespace FinalProject
{
    public partial class Profile : System.Web.UI.Page
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

                        if (!IsPostBack)
                        {
                            imgProfilePic.ImageUrl = "/Uploads/" + user.getPicture() + ".png";
                            imgProfilePic.Width = 100;
                            imgProfilePic.Height = 100;

                            txtUsername.Text = user.getUsername();
                            txtName.Text = user.getName();
                            txtEmail.Text = user.getEmail();
                            txtPhone.Text = user.getPhone();
                        }



                        if (user.GetType() == typeof(Buyer))
                        {
                            lblCompany.Visible = false;
                            txtCompany.Visible = false;
                            divPurchaseHistory.Visible = true;

                            List<Product> products = user.getMyProducts();
                            if (products != null)
                            {
                                foreach (var p in products)
                                {
                                    TableRow row = new TableRow();
                                    TableCell cell1 = new TableCell();
                                    TableCell cell2 = new TableCell();
                                    TableCell cell3 = new TableCell();
                                    TableCell cell4 = new TableCell();
                                    cell1.Text = p.getName();
                                    cell2.Text = p.getDescription();
                                    cell3.Text = p.getPrice().ToString();
                                    cell4.Text = p.getCategory();

                                    row.Cells.Add(cell1);
                                    row.Cells.Add(cell2);
                                    row.Cells.Add(cell3);
                                    row.Cells.Add(cell4);
                                    tblPurchaseHistory.Rows.Add(row);
                                }
                            }
                        }
                        else
                        {
                            divPurchaseHistory.Visible = false;
                            txtCompany.Visible = true;
                            txtCompany.Text = user.getCompany();
                            
                        }
                    }
                    else
                    {
                        Response.Redirect("https://localhost:44309/Login");
                    }


                }
                else
                {
                    Response.Redirect("https://localhost:44309/Login");
                }
            
            
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            txtName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            btnEdit.Visible = false;
            btnSubmit.Visible = true;
            uplProfilePic.Visible = true;
            btnDelete.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = true;
            btnSubmit.Visible = false;


            if (user != null)
            {

                if (uplProfilePic.HasFile)
                {
                    String fileId = user.uploadProfileImage();
                    if (fileId != "error")
                    {
                        //Deletes old file
                        String picId = user.getPicture();
                        if (picId != "" || picId != null)
                        {
                            String deletePath = Path.Combine(Server.MapPath("~/Uploads"), picId + ".png");
                            File.Delete(deletePath);
                        }

                        //Saves new file
                        String uploadPath = Path.Combine(Server.MapPath("~/Uploads"), fileId + ".png"); //Path.GetExtension(FileUpload.FileName)
                        uplProfilePic.PostedFile.SaveAs(uploadPath);
                        imgProfilePic.ImageUrl = "/Uploads/" + fileId + ".png";
                        imgProfilePic.Width = 100;
                        imgProfilePic.Height = 100;
                    }
                }


                //Update Contact Info
                String name = txtName.Text;
                String phone = txtPhone.Text;
                String email = txtEmail.Text;
                String username = txtUsername.Text;
                if (user.GetType() == typeof(Seller))
                {
                    String company = txtCompany.Text; //only if seller
                    if (company != user.getCompany())
                    {
                        user.setCompany(company);
                    }
                }

                if (username != user.getUsername())
                {
                    user.setUsername(username);
                }
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

                user.changeAccountInfo();

            }
            else
            {
                Debug.Print("user is null");
            }

            txtUsername.ReadOnly = true;
            txtName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
            btnEdit.Visible = true;
            btnSubmit.Visible = false;
            uplProfilePic.Visible = false;
            btnDelete.Visible = true;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                user.deleteAccount();
                Response.Redirect("https://localhost:44309/Login");
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Authenticate auth = new Authenticate();
            auth.setClientToken(Response, "None");
            Response.Redirect("https://localhost:44309/Login");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44309/ChangePassword");

        }
    }
}