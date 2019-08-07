// Author: Michael Coulter
// Student ID: 991 357 577

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

        public bool addProduct(Product product)
        {
            Database db = new Database();
            if (db.addProduct(product))
            {
                return true;
            }

            return false;
        }

        public bool deleteProduct(Product product)
        {
            Database db = new Database();
            if (db.deleteProduct(this, product))
            {
                return true;
            }
            return false;
        }

        public bool updateProduct(Product product)
        {
            Database db = new Database();
            if (db.updateProduct(this, product))
            {
                return true;
            }
            return false;
        }

        public bool replyToEnquiry(Enquiry enq)
        {
            Database db = new Database();
            if (db.replyToEnquiry(this, enq))
            {
                return true;
            }

            return false;
        }

    }
}