using System;

namespace Models.Common.Intefaces
{
    public interface IAuthRepository<TUser>
    {
        void Register(TUser user);
        TUser Login(string login, string passwd);
    }
}
