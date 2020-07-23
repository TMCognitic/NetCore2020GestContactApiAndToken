using GestContact.MVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestContact.MVC.Areas.Admin.Infractructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminRequiredAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return !(SessionManager.User is null) && SessionManager.User.IsAdmin;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpNotFoundResult();
        }
    }
}