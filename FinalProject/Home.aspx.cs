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

                    if (user.GetType() == typeof(Seller))
                    {
                        AccountStatus.Text = "Account Type: Seller";
                    } else
                    {
                        AccountStatus.Text = "Account Type: Buyer";
                    }
                    
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

        //All Options
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Authenticate auth = new Authenticate();
                auth.setClientToken(Response, "None");
                Response.Redirect("https://localhost:44309/Login");
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

                if (FileUpload.HasFile)
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
                        FileUpload.PostedFile.SaveAs(uploadPath);
                        profilePic.ImageUrl = "/Uploads/" + fileId + ".png";
                        profilePic.Width = 100;
                        profilePic.Height = 100;
                    }
                } else
                {
                    //No File
                }
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            String username = "billy1";
            String password = "123";
            int type = 1;
            String name = "Billy1";
            String phone = "647-343-2342";
            String email = "Bill@billy.com";
            String company = "Billy Inc";

            Account billy = new Account("", username, password, type, name, phone, email, company, "", ""); //Blank fields will be autofilled or not needed.
            int status = billy.createAccount();

            if (status == 0)
            {
                //Success
            } else if (status == 1)
            {
                //username taken
            } else if (status == 2)
            {
                //error
            }
        }

        protected void ButtonGetMyProducts_Click(object sender, EventArgs e)
        {
            
            if (user != null)
            {
                List<Product> products = user.getMyProducts();
                if (products != null)
                {
                    foreach (var p in products)
                    {
                        TableRow row = new TableRow();
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        TableCell cell3 = new TableCell();
                        cell1.Text = p.getName();
                        cell2.Text = p.getCategory();
                        cell3.Text = p.getPrice().ToString();
 

                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        row.Cells.Add(cell3);
                        myTableProducts.Rows.Add(row);
                    }
                    
                } else
                {
                    //error
                }
                 
            }
        }

        protected void ButtonGetEnquiries_Click(object sender, EventArgs e)
        {

            if (user != null)
            {
                List<Enquiry> enqs = user.getMyEnquiries();

                //test table
                foreach (var i in enqs)
                {
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    cell1.Text = i.getSubject();
                    cell2.Text = i.getQuestions();
                    cell3.Text = i.getResponse();
                    if (cell3.Text == "")
                    {
                        cell3.Text = "<button onClick='alert()'>Open Response Modal</button>";
                    }

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    myTable.Rows.Add(row);
                }
            }
        }

        //Seller Options
        protected void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            //Is a seller
            if (user != null && user.GetType() == typeof(Seller))
            {
                String id = "";
                String sellerId = user.getId();
                String buyerId = "";
                String name = "CounterStrike GO";
                String category = "Video Games";
                String description = "";
                double price = 60.00;

                Product product = new Product(id, sellerId, buyerId, category, price, description, name);
                Seller seller = (Seller)user;

                seller.addProduct(product);

            }
        }

        protected void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            //Is a seller
            if (user != null && user.GetType() == typeof(Seller))
            {
                String id = "1FFHNG1YSDRPVIFBH7Q8FL3U8MYX6W03WH8IWIPJBMF9RQ0OUS93EBNQLVJARD15";
                Product product = new Product(id);
                Seller seller = (Seller)user;

                if (seller.deleteProduct(product))
                {
                    Debug.WriteLine("DELETE");
                } else
                {
                    Debug.WriteLine("ERROR");
                }
                 
            }
        }

        protected void ButtonEditProduct_Click(object sender, EventArgs e)
        {
            //Is a seller
            if (user != null && user.GetType() == typeof(Seller))
            {
                String id = "F0XMVSOSFAWY3RJ5EVPNDQBNCU1QR4RW894VR40GUJK76AJA20ZNLE5YYKJB07AL";
                String name = "New Name";
                String category = "New Category";
                String description = "New Desc";
                double price = 5.00;
                
                Product product = new Product(id, "", "", category, price, description, name);

                Seller seller = (Seller)user;
                if (seller.updateProduct(product))
                {
                    //completed
                } else
                {
                    //error
                }

            }
        }

        protected void ButtonRespondEnquiry_Click(object sender, EventArgs e)
        {

            if (user != null && user.GetType() == typeof(Seller))
            {

                String enquiryId = "ZZ4AFATA4OYOV1M7YP7GHK1PPGMI4JZK3V61D5S9369ACM1VH903JWTO8PU8XLFV";
                String response = "Hello this is a response";
  
                Enquiry enq = new Enquiry(enquiryId, response);

                Seller seller = (Seller)user;
                if (seller.replyToEnquiry(enq))
                {
                    Debug.WriteLine("Replied");
                }
                else
                {
                    //error
                }
            }
        }

        //Buyer Options
        protected void ButtonForSaleProducts_Click(object sender, EventArgs e)
        {
            //Is a Buyer
            if (user != null && user.GetType() == typeof(Buyer))
            {
                Buyer buyer = (Buyer)user;
                List<Product> products = buyer.getProductsForSale();
                if (products != null)
                {
                    foreach (var p in products)
                    {
                        Debug.WriteLine(p.getPrice());
                    }

                }
                else
                {
                    //error
                }

            }
        }

        protected void ButtonBuyProduct_Click(object sender, EventArgs e)
        {
            //Is a Buyer
            if (user != null && user.GetType() == typeof(Buyer))
            {

                String productId = "GVFTHBY6URMRU50D0R1J8TNCOYA8IJKCEIMBKB40W0QWLE9SJ98PG25WHDFSAZXL";

                Product product = new Product(productId);  

                Buyer buyer = (Buyer)user;

                if (buyer.buyProduct(product))
                {
                    Debug.WriteLine("Bought");
                } else
                {
                    //err
                }
                

            }
        }

        protected void ButtonCreateEnquiry_Click(object sender, EventArgs e)
        {
            //Is a Buyer
            if (user != null && user.GetType() == typeof(Buyer))
            {

                String sellerId = ""; 
                String buyerId = user.getId();
                String subject = "Question";
                String questions = "Hey, is the disk scratched?";
                String response = ""; //leave blank when creating

                Enquiry enq = new Enquiry("", sellerId, buyerId, subject, questions, response);

                Buyer buyer = (Buyer)user;
                if (buyer.contactSeller(enq))
                {
                    Debug.WriteLine("Created");
                } else
                {
                    //error
                }
            }
        }

    }
}