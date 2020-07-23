using GestContact.MVC.Infrastructure;
using GestContact.MVC.Models.Forms;
using Models.Client.Entities;
using Models.Client.Services;
using Models.Common.Intefaces;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GestContact.MVC.Controllers
{
    public class AuthController : Controller
    {
        private IAuthRepository<User> _authRepostory;

        public AuthController()
        {
            _authRepostory = new AuthService();
        }

        // GET: Auth
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AnonymousRequired]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousRequired]
        public ActionResult Login(LoginForm form)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    User u = _authRepostory.Login(form.Email, form.Passwd);

                    if(!(u is null))
                    {
                        SessionManager.User = u;

                        if(Request.QueryString.AllKeys.Contains("Url"))
                        {
                            return Redirect(Request.QueryString["Url"]);
                        }

                        return RedirectToAction("Index", "Contact");
                    }
                    else
                    {
                        ViewBag.Error = "Erreur de login ou de mot de passe";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            return View(form);
        }

        [AnonymousRequiredAttribute]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousRequiredAttribute]
        public ActionResult Register(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authRepostory.Register(new User(form.LastName, form.FirstName, form.Email, form.Passwd));
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            return View(form);
        }

        [AuthRequired]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}