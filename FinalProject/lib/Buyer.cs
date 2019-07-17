using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Buyer : Account
    {

        public Buyer(String id, String name, String phone, String email, String company, String token) : base(id, name, phone, email, company, token)
        {

        }



    }
}