using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Buyer : Account
    {

        public Buyer(String id, String username, String password, int type, String name, String phone, String email, String company, String token, String picture) : base(id,username, password, type, name, phone, email, company, token, picture)
        {

        }

        public List<Product> getProductsForSale()
        {
            Database db = new Database();
            return db.getProductsForSale();
        }

        public bool buyProduct(Product product)
        {
            Database db = new Database();
            if (db.buyProduct(this, product))
            {
                return true;
            }
            return false;
        }

        public bool contactSeller(Enquiry enq)
        {
            Database db = new Database();
            if (db.createEnquiry(this, enq))
            {
                return true;
            }
            return false;
        }
    }
}