using GestContact.Api.Infrastructure;
using Models.Global.Intefaces;
using Models.Global.Entities;
using Models.Global.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestContact.Api.Controllers
{
    [AuthRequired]
    public class ContactController : ApiController
    {
        IContactRepository<Contact> _contactRepository;

        public ContactController()
        {
            _contactRepository = new ContactRepository();
        }

        // GET api/values
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.Get(GetUserId());
        }

        // GET api/values/5
        public Contact Get(int id)
        {
            return _contactRepository.Get(GetUserId(), id);
        }

        // POST api/values
        public Contact Post([FromBody] Contact contact)
        {
            return _contactRepository.Insert(contact);
        }

        // PUT api/values/5
        public bool Put(int id, [FromBody] Contact contact)
        {
            return _contactRepository.Update(id, contact);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _contactRepository.Delete(GetUserId(), id);
        }

        private int GetUserId()
        {
            return (int)RequestContext.RouteData.Values["userId"];
        }
    }
}
