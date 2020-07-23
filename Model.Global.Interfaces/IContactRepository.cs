using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Global.Intefaces
{
    public interface IContactRepository<TContact>
    {
        IEnumerable<TContact> Get(int userId);
        TContact Get(int userId, int id);
        TContact Insert(TContact entity);
        bool Update(int id, TContact entity);
        bool Delete(int userId, int id);
    }
}
