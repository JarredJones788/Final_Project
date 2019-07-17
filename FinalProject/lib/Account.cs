using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Account
    {
        private String id;
        private String username;
        private String password;
        private int type;
        private String name;
        private String phone;
        private String email;
        private String company;
        private String token;
        private String picture;

        public Account(String id, String username, String password, int type, String name, String phone, String email, String company, String token, String picture)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.type = type;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.company = company;
            this.token = token;
            this.picture = picture;
        }

        public String getId()
        {
            return this.id;
        }
        public String getUsername()
        {
            return this.username;
        }
        public String getPassword()
        {
            return this.password;
        }
        public int getType()
        {
            return this.type;
        }
        public String getName()
        {
            return this.name;
        }
        public String getPhone()
        {
            return this.phone;
        }
        public String getEmail()
        {
            return this.email;
        }
        public String getCompany()
        {
            return this.company;
        }
        public String getToken()
        {
            return this.token;
        }
        public String getPicture()
        {
            return this.picture;
        }



        public void setUsername(String username)
        {
            this.username = username;
        }
        public void setPassword(String password)
        {
            this.password = password;
        }
        public void setType(int type)
        {
            this.type = type;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setPhone(String phone)
        {
            this.phone = phone;
        }
        public void setEmail(String email)
        {
            this.email = email;
        }
        public void setCompany(String company)
        {
            this.company = company;
        }

        public bool changePassword(String newPassword)
        {
            Database db = new Database();
            if (db.updateUserPassword(newPassword, this.id))
            {
                return true;
            }

            return false;
        }
        public bool changeAccountInfo()
        {
            Database db = new Database();
            if (db.updateAccountInfo(this))
            {
                return true;
            }

            return false;
        }
        public String uploadProfileImage()
        {
            Database db = new Database();
            return db.uploadProfileImage(this.id);
        }

        public bool createAccount()
        {
            Database db = new Database();
            return db.createAccount(this);
        }
    }
}