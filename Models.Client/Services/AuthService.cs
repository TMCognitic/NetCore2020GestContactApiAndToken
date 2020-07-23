using Models.Client.Entities;
using Models.Client.Mappers;
using Models.Common.Intefaces;
using G = Models.Global.Entities;
using Models.Global.Services;
using System;
using System.Collections.Generic;
using System.Text;


namespace Models.Client.Services
{
    public class AuthService : IAuthRepository<User>
    {
        IAuthRepository<G.User> _globalRepository;

        public AuthService()
        {
            _globalRepository = new AuthRepository();
        }

        public User Login(string login, string passwd)
        {
            return _globalRepository.Login(login, passwd)?.ToClient();
        }

        public void Register(User user)
        {
            _globalRepository.Register(user.ToGlobal());
            user.Passwd = null;
        }
    }
}
