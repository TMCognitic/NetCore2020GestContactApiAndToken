using GestContact.MVC.Infrastructure;
using GestContact.MVC.Models.Forms;
using GestContact.MVC.Models.Forms.Extensions;
using Models.Global.Api.Interfaces;
using Models.Client.Services;
using Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestContact.MVC.Controllers
{
    [AuthRequired]
    public class ContactController : Controller
    {
        private IContactRepository<Contact> _contactRepository;

        public ContactController()
        {
            _contactRepository = new ContactService(SessionManager.User.Token);
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(_contactRepository.Get().Select(c => c.ToContactForm()));
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            Contact contact = _contactRepository.Get(id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(contact.ToDetailContactForm());
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateContactForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contactRepository.Insert(new Contact(form.LastName, form.FirstName, form.Email, SessionManager.User.Id, form.Phone));                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            return View(form);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            Contact contact = _contactRepository.Get(id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(contact.ToUpdateContactForm());
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateContactForm form)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(_contactRepository.Update(id, new Contact(form.LastName, form.FirstName, form.Email, SessionManager.User.Id, form.Phone)))
                    {
                        return RedirectToAction("Index");
                    }

                    ViewBag.Error = "Oups something wrong!!";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            return View(form);
            
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            Contact contact = _contactRepository.Get(id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(contact.ToDetailContactForm());
        }

        // POST: Contact/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _contactRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
