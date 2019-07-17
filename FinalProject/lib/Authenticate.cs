
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Authenticate
    {

        public Account login(String username, String password)
        {
            Database db = new Database();
            SqlDataReader dr = db.getData($"SELECT * FROM users WHERE username = '{username}'");

            while (dr.Read())
            {
                if (dr.GetString(2) == password)
                {
                    String id = dr.GetString(0);
                    String user = dr.GetString(1);
                    String pass = dr.GetString(2);
                    int type = dr.GetInt32(3);
                    String name = dr.GetString(4);
                    String phone = dr.GetString(5);
                    String email = dr.GetString(6);
                    String company = dr.GetString(7);
                    String token = this.createAuthToken();
                    String picture = dr.GetString(9);

                    if (dr.GetInt32(3) == 1) 
                    {
                        dr.Close();
                        db.updateUserToken(token, id);
                        return new Seller(id, user, pass, type, name, phone, email, company, token, picture);
                    } else
                    {
                        dr.Close();
                        db.updateUserToken(token, id);
                        return new Buyer(id, user, pass, type, name, phone, email, company, token, picture);
                    }
                }
            }

            return null;
        }

        public Account checkSession(String authToken)
        {
            Database db = new Database();
            SqlDataReader dr = db.getData($"SELECT * FROM users WHERE token = '{authToken}'");

            while (dr.Read())
            {
                String id = dr.GetString(0);
                String user = dr.GetString(1);
                String pass = dr.GetString(2);
                int type = dr.GetInt32(3);
                String name = dr.GetString(4);
                String phone = dr.GetString(5);
                String email = dr.GetString(6);
                String company = dr.GetString(7);
                String token = dr.GetString(8);
                String picture = dr.GetString(9);

                if (dr.GetInt32(3) == 1) //seller
                {
                    dr.Close();
                    db.updateUserToken(token, id);
                    return new Seller(id, user, pass, type, name, phone, email, company, token, picture);
                }
                else
                {
                    dr.Close();
                    db.updateUserToken(token, id);
                    return new Buyer(id, user, pass, type, name, phone, email, company, token, picture);
                }
            }

            return null;
        }

        private String createAuthToken()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 64)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void setClientToken(HttpResponse response, String token)
        {
            HttpCookie myCookie = new HttpCookie("token", token);
            myCookie.Expires = DateTime.Now.AddHours(12);
            response.Cookies.Add(myCookie);
        }

    }
}