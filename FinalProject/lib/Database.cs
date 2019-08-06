using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Database
    {
        private SqlConnection conn;
        private SqlDataReader reader;

        public Database()
        {
            this.conn = new SqlConnection(@"Server=LAPTOP-AB9DVTVR\DITMARSSQL;Database=Project;User Id=sa; Password=bEeR2D1X;");
            this.conn.Open();
        }

        public SqlDataReader getData(String query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.conn);

                this.reader = cmd.ExecuteReader();

                return this.reader;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());

                return null;

            }
        }

        public bool updateUserToken(String token, String id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "UPDATE users SET token = @Token WHERE id = @Id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Token", token);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                this.conn.Close();

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false;

            }
        }

        public bool updateUserPassword(String newPassword, String id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "UPDATE users SET password = @Password WHERE id = @Id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                this.conn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false;

            }
        }

        public bool updateAccountInfo(Account account)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "UPDATE users SET name = @Name, phone = @Phone, email = @email, company = @Company WHERE id = @Id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Name", account.getName());
                cmd.Parameters.AddWithValue("@Phone", account.getPhone());
                cmd.Parameters.AddWithValue("@Email", account.getEmail());
                cmd.Parameters.AddWithValue("@Company", account.getCompany());
                cmd.Parameters.AddWithValue("@Id", account.getId());
                cmd.ExecuteNonQuery();

                this.conn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false;

            }
        }

        public string uploadProfileImage(String id)
        {

            String imageId = this.createRandomId();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "UPDATE users SET picture = @Picture WHERE id = @Id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Picture", imageId);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();


                this.conn.Close();
                return imageId;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return "error";

            }
        }

        public int createAccount(Account account)
        {

            String userId = this.createRandomId();

            try
            {

                SqlDataReader dr = getData($"SELECT * FROM users WHERE username = '{account.getUsername()}'");

                bool usernameTaken = false;
                while (dr.Read())
                {
                    usernameTaken = true;
                }

                dr.Close();

                if (!usernameTaken)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = this.conn;
                    cmd.CommandText = "INSERT INTO users (id, username, password, type, name, phone, email, company) VALUES(@Id, @Username, @Password, @Type, @Name, @Phone, @Email, @Company)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@Username", account.getUsername());
                    cmd.Parameters.AddWithValue("@Password", account.getPassword());
                    cmd.Parameters.AddWithValue("@Type", account.getType());
                    cmd.Parameters.AddWithValue("@Name", account.getName());
                    cmd.Parameters.AddWithValue("@Phone", account.getPhone());
                    cmd.Parameters.AddWithValue("@Email", account.getEmail());
                    cmd.Parameters.AddWithValue("@Company", account.getCompany());
                    cmd.ExecuteNonQuery();

                    this.conn.Close();
                    return 0; 
                }

                return 1; //Username is taken
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return 2; //error

            }
        }

        public bool addProduct(Product product)
        {
            String productId = this.createRandomId();

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "INSERT INTO products (id, sellerId, buyerId, category, price, description, name, sellerName, company) VALUES(@Id, @SellerId, @BuyerId, @Category, @Price, @Description, @Name, @SellerName, @Company)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", productId);
                cmd.Parameters.AddWithValue("@SellerId", product.getSellerId());
                cmd.Parameters.AddWithValue("@BuyerId", product.getBuyerId());
                cmd.Parameters.AddWithValue("@Category", product.getCategory());
                cmd.Parameters.AddWithValue("@Price", product.getPrice());
                cmd.Parameters.AddWithValue("@Description", product.getDescription());
                cmd.Parameters.AddWithValue("@Name", product.getName());
                cmd.Parameters.AddWithValue("@SellerName", product.getSellerName());
                cmd.Parameters.AddWithValue("@Company", product.getCompany());
                cmd.ExecuteNonQuery();

                this.conn.Close();

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false; //error

            }
        }

        public bool deleteProduct(Account account, Product product)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "DELETE FROM products WHERE id = @Id AND sellerId = @SellerId";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", product.getId());
                cmd.Parameters.AddWithValue("@SellerId", account.getId());

                cmd.ExecuteNonQuery();

                this.conn.Close();

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false; //error

            }
        }

        public bool updateProduct(Account account, Product product)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "UPDATE products SET category = @Category, price = @Price, description = @Description, name = @Name, sellerName = @SellerName, company = @Company WHERE id = @Id AND sellerId = @SellerId";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Category", product.getCategory());
                cmd.Parameters.AddWithValue("@Price", product.getPrice());
                cmd.Parameters.AddWithValue("@Description", product.getDescription());
                cmd.Parameters.AddWithValue("@Name", product.getName());
                cmd.Parameters.AddWithValue("@Id", product.getId());
                cmd.Parameters.AddWithValue("@SellerId", account.getId());
                cmd.Parameters.AddWithValue("@SellerName", account.getName());
                cmd.Parameters.AddWithValue("@Company", account.getCompany());

                cmd.ExecuteNonQuery();

                this.conn.Close();

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false; //error

            }
        }

        public bool buyProduct(Account account, Product product)
        {

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "UPDATE products SET buyerId = @BuyerId WHERE id = @Id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", product.getId());
                cmd.Parameters.AddWithValue("@BuyerId", account.getId());

                cmd.ExecuteNonQuery();

                this.conn.Close();

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false; //error

            }
        }

        public List<Product> getMyProducts(Account account)
        {

            try
            {
                SqlDataReader dr;
                if (account.GetType() == typeof(Seller))
                {
                    dr = getData($"SELECT * FROM products WHERE sellerId = '{account.getId()}'");
                } else
                {
                    dr = getData($"SELECT * FROM products WHERE buyerId = '{account.getId()}'");
                }

                List<Product> myProducts = new List<Product>();

                while (dr.Read())
                {
                    myProducts.Add(new Product(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetDouble(4), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetString(8)));
                }

                dr.Close();

                return myProducts;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return null; //error

            }
        }

        public List<Product> getProductsForSale()
        {

            try
            {
                SqlDataReader dr = getData($"SELECT * FROM products WHERE buyerId = ''");

                List<Product> allProducts = new List<Product>();

                while (dr.Read())
                {
                    allProducts.Add(new Product(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetDouble(4), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetString(8)));
                }

                dr.Close();

                return allProducts;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return null; //error

            }
        }

        public bool createEnquiry(Account account, Enquiry enq)
        {
            String enquiryId = this.createRandomId();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "INSERT INTO enquiries (id, sellerId, buyerId, subject, questions, response) VALUES(@Id, @SellerId, @BuyerId, @Subject, @Questions, @Response)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", enquiryId);
                cmd.Parameters.AddWithValue("@SellerId", enq.getSellerId());
                cmd.Parameters.AddWithValue("@BuyerId", enq.getBuyerId());
                cmd.Parameters.AddWithValue("@Subject", enq.getSubject());
                cmd.Parameters.AddWithValue("@Questions", enq.getQuestions());
                cmd.Parameters.AddWithValue("@Response", enq.getResponse());

                cmd.ExecuteNonQuery();

                this.conn.Close();

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false; //error

            }
        }

        public bool replyToEnquiry(Account account, Enquiry enq)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "UPDATE enquiries SET response = @Response WHERE id = @EnquiryId AND sellerId = @SellerId";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@EnquiryId", enq.getId());
                cmd.Parameters.AddWithValue("@Response", enq.getResponse());
                cmd.Parameters.AddWithValue("@SellerId", account.getId());


                cmd.ExecuteNonQuery();

                this.conn.Close();

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false; //error

            }
        }

        public List<Enquiry> getMyEnquiries(Account account)
        {

            try
            {

                SqlDataReader dr;
                if (account.GetType() == typeof(Seller))
                {
                    dr = getData($"SELECT * FROM enquiries WHERE sellerId = '{account.getId()}'");
                }
                else
                {
                    dr = getData($"SELECT * FROM enquiries WHERE buyerId = '{account.getId()}'");
                }


                List<Enquiry> Enquiries = new List<Enquiry>();

                while (dr.Read())
                {
                    Enquiries.Add(new Enquiry(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5)));
                }

                dr.Close();

                return Enquiries;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return null; //error

            }
        }

        private String createRandomId()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 64)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}