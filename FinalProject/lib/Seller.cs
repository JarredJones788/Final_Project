using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Seller : Account
    {

        public Seller(String id, String username, String password, int type, String name, String phone, String email, String company, String token, String picture) : base(id, username, password, type, name, phone, email, company, token, picture)
        {

        }



    }
}