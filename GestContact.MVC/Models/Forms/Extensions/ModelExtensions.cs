using Microsoft.Ajax.Utilities;
using Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestContact.MVC.Models.Forms.Extensions
{
    public static class ModelExtensions
    {
        public static ContactForm ToContactForm(this Contact contact)
        {
            return new ContactForm() { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName };
        }

        public static DetailContactForm ToDetailContactForm(this Contact contact)
        {
            return new DetailContactForm() { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName, Email = contact.Email, Phone = contact.Phone };
        }

        public static UpdateContactForm ToUpdateContactForm(this Contact contact)
        {
            return new UpdateContactForm() { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName, Email = contact.Email, Phone = contact.Phone };
        }
    }
}