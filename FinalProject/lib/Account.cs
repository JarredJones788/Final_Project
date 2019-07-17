using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Account
    {
        private String id;
        private String name;
        private String phone;
        private String email;
        private String company;
        private String token;

        public Account(String id, String name, String phone, String email, String company, String token)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.company = company;
            this.token = token;
        }

        public String getId()
        {
            return this.id;
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

    }
}