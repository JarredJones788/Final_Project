using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace FinalProject.lib
{
    public class Database
    {
        private MySqlConnection conn;
        private MySqlDataReader dr;

        public Database()
        {
            this.conn = new MySqlConnection(@"server=localhost;userid=root;password=123;database=project");
            this.conn.Open();
        }

        public MySqlDataReader getData(String query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, this.conn);

                this.dr = cmd.ExecuteReader();

                return this.dr;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;

            }
        }
        public bool updateUserToken(String token, String id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "UPDATE users SET token = @Token WHERE id = @Id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Token", token);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;

            }
        }
    }
}