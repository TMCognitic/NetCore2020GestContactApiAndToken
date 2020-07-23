using Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestContact.MVC.Infrastructure
{
    public static class SessionManager
    {
        public static User User
        {
            get { return (User)HttpContext.Current.Session[nameof(User)]; }
            set { HttpContext.Current.Session[nameof(User)] = value; }
        }
    }
}