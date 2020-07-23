using GestContact.Api.Models;
using GestContact.Api.Models.Services;
using Models.Common.Intefaces;
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
    public class AuthController : ApiController
    {
        IAuthRepository<User> _authRepository;

        public AuthController()
        {
            _authRepository = new AuthRepository();
        }

        [HttpPost]
        [Route("api/auth/login")]
        public User Login([FromBody] LoginForm form)
        {
            User user = _authRepository.Login(form.Login, form.Passwd);

            if (!(user is null))
                user.Token = TokenService.Instance.EncodeToken(user);

            return user;
        }

        [HttpPost]
        [Route("api/auth/register")]
        public void Register([FromBody] User user)
        {
            _authRepository.Register(user);
        }
    }
}
