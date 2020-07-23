using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestContact.MVC.Models.Forms
{
    public class ContactForm
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}