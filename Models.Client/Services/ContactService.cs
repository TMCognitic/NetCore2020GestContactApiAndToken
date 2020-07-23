using Models.Client.Entities;
using G = Models.Global.Entities;
using Models.Global.Api.Interfaces;
using Models.Global.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Client.Mappers;

namespace Models.Client.Services
{
    public class ContactService : IContactRepository<Contact>
    {
        IContactRepository<G.Contact> _globalRepository;

        public ContactService(string token)
        {
            _globalRepository = new ContactRepository(token);
        }        

        public IEnumerable<Contact> Get()
        {
            return _globalRepository.Get().Select(c => c.ToClient());
        }

        public Contact Get(int id)
        {
            return _globalRepository.Get(id)?.ToClient();
        }

        public Contact Insert(Contact entity)
        {
            return _globalRepository.Insert(entity.ToGlobal())?.ToClient();
        }

        public bool Update(int id, Contact entity)
        {
            return _globalRepository.Update(id, entity.ToGlobal());
        }

        public bool Delete(int id)
        {
            return _globalRepository.Delete(id);
        }
    }
}
