using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Global.Api.Interfaces
{
    public interface IContactRepository<TContact>
    {
        IEnumerable<TContact> Get();
        TContact Get(int id);
        TContact Insert(TContact entity);
        bool Update(int id, TContact entity);
        bool Delete(int id);
    }
}
