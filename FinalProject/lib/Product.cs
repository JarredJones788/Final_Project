﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Product
    {
        private String id;
        private String sellerId;
        private String buyerId;
        private String category;
        private double price;
        private String description;
        private String name;

        public Product(String id, String sellerId, String buyerId, String category, double price, String description, String name)
        {
            this.id = id;
            this.sellerId = sellerId;
            this.buyerId = buyerId;
            this.category = category;
            this.price = price;
            this.description = description;
            this.name = name;
        }
        public Product(String id)
        {
            this.id = id;
        }

        public String getId()
        {
            return this.id;
        }
        public String getSellerId()
        {
            return this.sellerId;
        }
        public String getBuyerId()
        {
            return this.buyerId;
        }
        public String getCategory()
        {
            return this.category;
        }
        public double getPrice()
        {
            return this.price;
        }
        public String getDescription()
        {
            return this.description;
        }
        public String getName()
        {
            return this.name;
        }



    }
}