using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class Enquiry
    {
        private String id;
        private String sellerId;
        private String buyerId;
        private String subject;
        private String questions;
        private String response;

        public Enquiry(String id, String sellerId, String buyerId, String subject, String questions, String response)
        {
            this.id = id;
            this.sellerId = sellerId;
            this.buyerId = buyerId;
            this.subject = subject;
            this.questions = questions;
            this.response = response;
        }
        public Enquiry(String id, String response)
        {
            this.id = id;
            this.response = response;
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
        public String getSubject()
        {
            return this.subject;
        }
        public String getQuestions()
        {
            return this.questions;
        }
        public String getResponse()
        {
            return this.response;
        }

    }
}