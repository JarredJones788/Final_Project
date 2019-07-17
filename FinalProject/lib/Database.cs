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
            this.conn = new SqlConnection(@"Server=JARRED\PROJECTSQL;Database=Project;User Id=sa; Password=123;");
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

        public bool createAccount(Account account)
        {

            String userId = this.createRandomId();

            try
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
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                this.conn.Close();
                return false;

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