// Author: Michael Coulter
// Student ID: 991 357 577

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
        List<Product> products;
        List<Enquiry> enqs;
        List<Product> buyable;


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

                    if (user.GetType() == typeof(Seller))
                    {
                        sellerPanel.Visible = true;
                        this.products = user.getMyProducts();
                        if (this.products != null)
                        {
                            foreach (var p in this.products)
                            {
                                TableRow row = new TableRow();
                                TableCell cell1 = new TableCell();
                                TableCell cell2 = new TableCell();
                                TableCell cell3 = new TableCell();
                                TableCell cell4 = new TableCell();
                                TableCell cell5 = new TableCell();

                                Button btn = new Button();
                                btn.Text = "Edit";
                                btn.CssClass = "btn btn-primary";
                                btn.CommandArgument = p.getId();
                                btn.Click += new EventHandler(EditProduct_Click);

                                cell1.Text = p.getName();
                                cell2.Text = p.getCategory();
                                cell3.Text = p.getPrice().ToString();
                                cell4.Text = p.getDescription();
                                cell5.Controls.Add(btn);

                                row.Cells.Add(cell1);
                                row.Cells.Add(cell2);
                                row.Cells.Add(cell3);
                                row.Cells.Add(cell4);
                                row.Cells.Add(cell5);
                                yourProducts.Rows.Add(row);
                            }

                             this.enqs = user.getMyEnquiries();

                            foreach (var i in this.enqs)
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
                                    Button btn = new Button();
                                    btn.Text = "Respond";
                                    btn.CssClass = "btn btn-primary";
                                    btn.CommandArgument = i.getId();
                                    btn.Click += new EventHandler(EnquiryResponse_Click);
                                    cell3.Controls.Add(btn);
                                }

                                row.Cells.Add(cell1);
                                row.Cells.Add(cell2);
                                row.Cells.Add(cell3);
                                yourEnquiries.Rows.Add(row);
                            }

                        }

                    } else
                    {
                        buyerPanel.Visible = true;

                        this.enqs = user.getMyEnquiries();

                        foreach (var i in this.enqs)
                        {
                            TableRow row = new TableRow();
                            TableCell cell1 = new TableCell();
                            TableCell cell2 = new TableCell();
                            TableCell cell3 = new TableCell();
                            cell1.Text = i.getSubject();
                            cell2.Text = i.getQuestions();
                            cell3.Text = i.getResponse();


                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            row.Cells.Add(cell3);
                            buyerEnquiries.Rows.Add(row);
                        }

                        Buyer buyer = (Buyer)user;
                        List<Product> products = buyer.getProductsForSale();
                        this.buyable = products;
                        if (products != null)
                        {
                            productsForSale.Rows.Clear();
                            drawTableHeader();

                            switch (searchFilter.SelectedValue)
                            {
                                case "category":
                                    foreach (var p in this.buyable)
                                    {
                                        if (p.getCategory().ToUpper().Contains(productSearchBar.Text.ToUpper()))
                                        {
                                            TableRow row = new TableRow();
                                            TableCell cell1 = new TableCell();
                                            TableCell cell2 = new TableCell();
                                            TableCell cell3 = new TableCell();
                                            TableCell cell4 = new TableCell();
                                            TableCell cell5 = new TableCell();

                                            Button btn = new Button();
                                            btn.Text = "Buy";
                                            btn.CssClass = "btn btn-primary";
                                            btn.CommandArgument = p.getId();
                                            btn.Click += new EventHandler(ButtonBuyProduct_Click);

                                            Button btn1 = new Button();
                                            btn1.Text = "Enquire";
                                            btn1.CssClass = "btn btn-primary";
                                            btn1.CommandArgument = p.getSellerId();
                                            btn1.Click += new EventHandler(enquireModal_Click);

                                            cell1.Text = p.getName();
                                            cell2.Text = p.getCategory();
                                            cell3.Text = p.getPrice().ToString();
                                            cell4.Text = p.getDescription();
                                            cell5.Controls.Add(btn);
                                            cell5.Controls.Add(btn1);

                                            row.Cells.Add(cell1);
                                            row.Cells.Add(cell2);
                                            row.Cells.Add(cell3);
                                            row.Cells.Add(cell4);
                                            row.Cells.Add(cell5);
                                            productsForSale.Rows.Add(row);
                                        }
                                    }


                                    break;
                                case "seller":
                                    foreach (var p in this.buyable)
                                    {
                                        if (p.getSellerName().ToUpper().Contains(productSearchBar.Text.ToUpper()))
                                        {
                                            TableRow row = new TableRow();
                                            TableCell cell1 = new TableCell();
                                            TableCell cell2 = new TableCell();
                                            TableCell cell3 = new TableCell();
                                            TableCell cell4 = new TableCell();
                                            TableCell cell5 = new TableCell();

                                            Button btn = new Button();
                                            btn.Text = "Buy";
                                            btn.CssClass = "btn btn-primary";
                                            btn.CommandArgument = p.getId();
                                            btn.Click += new EventHandler(ButtonBuyProduct_Click);

                                            Button btn1 = new Button();
                                            btn1.Text = "Enquire";
                                            btn1.CssClass = "btn btn-primary";
                                            btn1.CommandArgument = p.getSellerId();
                                            btn1.Click += new EventHandler(enquireModal_Click);

                                            cell1.Text = p.getName();
                                            cell2.Text = p.getCategory();
                                            cell3.Text = p.getPrice().ToString();
                                            cell4.Text = p.getDescription();
                                            cell5.Controls.Add(btn);
                                            cell5.Controls.Add(btn1);

                                            row.Cells.Add(cell1);
                                            row.Cells.Add(cell2);
                                            row.Cells.Add(cell3);
                                            row.Cells.Add(cell4);
                                            row.Cells.Add(cell5);
                                            productsForSale.Rows.Add(row);
                                        }
                                    }


                                    break;
                                case "company":
                                    foreach (var p in this.buyable)
                                    {
                                        if (p.getCompany().ToUpper().Contains(productSearchBar.Text.ToUpper()))
                                        {
                                            TableRow row = new TableRow();
                                            TableCell cell1 = new TableCell();
                                            TableCell cell2 = new TableCell();
                                            TableCell cell3 = new TableCell();
                                            TableCell cell4 = new TableCell();
                                            TableCell cell5 = new TableCell();

                                            Button btn = new Button();
                                            btn.Text = "Buy";
                                            btn.CssClass = "btn btn-primary";
                                            btn.CommandArgument = p.getId();
                                            btn.Click += new EventHandler(ButtonBuyProduct_Click);

                                            Button btn1 = new Button();
                                            btn1.Text = "Enquire";
                                            btn1.CssClass = "btn btn-primary";
                                            btn1.CommandArgument = p.getSellerId();
                                            btn1.Click += new EventHandler(enquireModal_Click);

                                            cell1.Text = p.getName();
                                            cell2.Text = p.getCategory();
                                            cell3.Text = p.getPrice().ToString();
                                            cell4.Text = p.getDescription();
                                            cell5.Controls.Add(btn);
                                            cell5.Controls.Add(btn1);

                                            row.Cells.Add(cell1);
                                            row.Cells.Add(cell2);
                                            row.Cells.Add(cell3);
                                            row.Cells.Add(cell4);
                                            row.Cells.Add(cell5);
                                            productsForSale.Rows.Add(row);
                                        }
                                    }


                                    break;
                                case "product":
                                    foreach (var p in this.buyable)
                                    {
                                        if (p.getName().ToUpper().Contains(productSearchBar.Text.ToUpper()))
                                        {
                                            TableRow row = new TableRow();
                                            TableCell cell1 = new TableCell();
                                            TableCell cell2 = new TableCell();
                                            TableCell cell3 = new TableCell();
                                            TableCell cell4 = new TableCell();
                                            TableCell cell5 = new TableCell();

                                            Button btn = new Button();
                                            btn.Text = "Buy";
                                            btn.CssClass = "btn btn-primary";
                                            btn.CommandArgument = p.getId();
                                            btn.Click += new EventHandler(ButtonBuyProduct_Click);

                                            Button btn1 = new Button();
                                            btn1.Text = "Enquire";
                                            btn1.CssClass = "btn btn-primary";
                                            btn1.CommandArgument = p.getSellerId();
                                            btn1.Click += new EventHandler(enquireModal_Click);

                                            cell1.Text = p.getName();
                                            cell2.Text = p.getCategory();
                                            cell3.Text = p.getPrice().ToString();
                                            cell4.Text = p.getDescription();
                                            cell5.Controls.Add(btn);
                                            cell5.Controls.Add(btn1);

                                            row.Cells.Add(cell1);
                                            row.Cells.Add(cell2);
                                            row.Cells.Add(cell3);
                                            row.Cells.Add(cell4);
                                            row.Cells.Add(cell5);
                                            productsForSale.Rows.Add(row);
                                        }
                                    }


                                    break;
                                default:
                                    foreach (var p in products)
                                    {
                                        TableRow row = new TableRow();
                                        TableCell cell1 = new TableCell();
                                        TableCell cell2 = new TableCell();
                                        TableCell cell3 = new TableCell();
                                        TableCell cell4 = new TableCell();
                                        TableCell cell5 = new TableCell();

                                        Button btn = new Button();
                                        btn.Text = "Buy";
                                        btn.CssClass = "btn btn-primary";
                                        btn.CommandArgument = p.getId();
                                        btn.Click += new EventHandler(ButtonBuyProduct_Click);

                                        Button btn1 = new Button();
                                        btn1.Text = "Enquire";
                                        btn1.CssClass = "btn btn-primary";
                                        btn1.CommandArgument = p.getSellerId();
                                        btn1.Click += new EventHandler(enquireModal_Click);

                                        cell1.Text = p.getName();
                                        cell2.Text = p.getCategory();
                                        cell3.Text = p.getPrice().ToString();
                                        cell4.Text = p.getDescription();
                                        cell5.Controls.Add(btn);
                                        cell5.Controls.Add(btn1);

                                        row.Cells.Add(cell1);
                                        row.Cells.Add(cell2);
                                        row.Cells.Add(cell3);
                                        row.Cells.Add(cell4);
                                        row.Cells.Add(cell5);
                                        productsForSale.Rows.Add(row);
                                    }
                                    break;
                            }

                        }
                        else
                        {
                            //error
                        }
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
        protected void drawTableHeader()
        {

            if (this.user != null)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();


                cell1.Text = "Name";
                cell2.Text = "Category";
                cell3.Text = "Price";
                cell4.Text = "Description";
                cell5.Text = "Actions";

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                productsForSale.Rows.Add(row);
            }


        }
        
        protected void EditProduct_Click(object sender, EventArgs e)
        {

            if (this.user != null)
            {
                if (this.products != null)
                {
                    Button btn = (Button)sender;

                    foreach (var p in this.products)
                    {
                        if (p.getId() == btn.CommandArgument)
                        {

                            editProductId.Text = p.getId();
                            editProductName.Text = p.getName();
                            editProductCategory.Text = p.getCategory();
                            editProductDescription.Text = p.getDescription();
                            editProductPrice.Text = p.getPrice().ToString();
                            break;
                        }
                    }


                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myProductsModal", "$('#myProductsModal').modal();", true);
                    productModalUpdate.Update();

                }
            }


        }
        protected void EnquiryResponse_Click(object sender, EventArgs e)
        {

            if (this.user != null)
            {
                Button btn = (Button)sender;

                foreach (var p in this.enqs)
                {
                    if (p.getId() == btn.CommandArgument)
                    {

                        respondId.Text = p.getId();
                        respondQuestion.Text = p.getQuestions();
                        respondSubject.Text = p.getSubject();
                        break;
                    }
                }


                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "respondModal", "$('#respondModal').modal();", true);
                respondUpdate.Update();
            }


        }

        protected void AddProductModal_Click(object sender, EventArgs e)
        {

            if (this.user != null)
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "addProductsModal", "$('#addProductsModal').modal();", true);
                addProductUpdate.Update();
            }


        }

        protected void enquireModal_Click(object sender, EventArgs e)
        {
            if (this.user != null)
            {
                Button btn = (Button)sender;
                enquireSellerId.Text = btn.CommandArgument;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "enquireModal", "$('#enquireModal').modal();", true);
                enquireUpdate.Update();
            }


        }

        //All Options


        //Seller Options
        protected void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            //Is a seller
            if (user != null && user.GetType() == typeof(Seller))
            {
                String id = "";
                String sellerId = user.getId();
                String buyerId = "";
                String name = addProductName.Text;
                String category = addProductCategory.Text;
                String description = addProductDescription.Text;
                String sellerName = user.getName();
                String company = user.getCompany();
                double price = Double.Parse(addProductPrice.Text);

                Product product = new Product(id, sellerId, buyerId, category, price, description, name, sellerName, company);
                Seller seller = (Seller)user;

                seller.addProduct(product);

                Response.Redirect(Request.RawUrl);

            }
        }

        protected void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            //Is a seller
            if (user != null && user.GetType() == typeof(Seller))
            {
                String id = editProductId.Text;
                Product product = new Product(id);
                Seller seller = (Seller)user;

                if (seller.deleteProduct(product))
                {
                    Response.Redirect(Request.RawUrl);
                } else
                {
                    Debug.WriteLine("ERROR DELETING PRODUCT");
                }
                 
            }
        }

        protected void ButtonEditProduct_Click(object sender, EventArgs e)
        {
            //Is a seller
            if (user != null && user.GetType() == typeof(Seller))
            {
                String id = editProductId.Text;
                String name = editProductName.Text;
                String category = editProductCategory.Text;
                String description = editProductDescription.Text;
                double price = Double.Parse(editProductPrice.Text);

                
                Product product = new Product(id, "", "", category, price, description, name, "", "");

                Seller seller = (Seller)user;
                if (seller.updateProduct(product))
                {
                    Response.Redirect(Request.RawUrl);
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

                String enquiryId = respondId.Text;
                String response = responseText.Text;
  
                Enquiry enq = new Enquiry(enquiryId, response);

                Seller seller = (Seller)user;
                if (seller.replyToEnquiry(enq))
                {
                    Debug.WriteLine("Replied");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    //error
                }
            }
        }

        //Buyer Options
        protected void ButtonBuyProduct_Click(object sender, EventArgs e)
        {
            //Is a Buyer
            if (user != null && user.GetType() == typeof(Buyer))
            {

                Button btn = (Button)sender;
                String productId = btn.CommandArgument;

                Product product = new Product(productId);  

                Buyer buyer = (Buyer)user;

                if (buyer.buyProduct(product))
                {
                    Debug.WriteLine("Bought");
                    Response.Redirect(Request.RawUrl);
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

                String sellerId = enquireSellerId.Text; 
                String buyerId = user.getId();
                String subject = addSubject.Text;
                String questions = addQuestion.Text;
                String response = ""; //leave blank when creating

                Enquiry enq = new Enquiry("", sellerId, buyerId, subject, questions, response);

                Buyer buyer = (Buyer)user;
                if (buyer.contactSeller(enq))
                {
                    Debug.WriteLine("Created");
                    Response.Redirect(Request.RawUrl);
                } else
                {
                    //error
                }
            }
        }

    }
}