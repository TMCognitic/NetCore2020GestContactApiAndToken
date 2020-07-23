using Microsoft.IdentityModel.Tokens;
using Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace GestContact.Api.Models.Services
{
    public sealed class TokenService
    {
        #region Singleton
        private static TokenService _instance;

        public static TokenService Instance
        {
            get
            {
                return _instance ?? (_instance = new TokenService());
            }
        }        

        private TokenService()
        {

        }
        #endregion

        private const string PassPhrase = "@3ut=N6U%L9@=G*#@QCY3e_sX6S&_CaZHLL!efhE!KXP958n4!p+QSJ2L-*jNZEGk_Hrc7hNE=*ZFatFZb#53r4=RupFWjzW7G9FvT+*_R@rVjCAswqqrjGH!P^6?MDs*NrzT7+4ePxpyVC&BB=-A6@vY&8eWFUwuYFkZL=vEvdZ4!B^XxG!n2v88JycztvhQZx?d&y%Gamf_%2%8vb&4WAenpWtZ*RdTPyE+UFW$Q?ppjFe&bmA-xKUvL5AnE=C";
        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;
        public JwtHeader Header
        {
            get
            {
                return _header ?? (_header = new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PassPhrase)), 
                        SecurityAlgorithms.HmacSha512)));
            }
        }

        public JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new JwtSecurityTokenHandler());
            }
        }

        public string EncodeToken(User user)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                Header,
                new JwtPayload(
                    issuer: null,
                    audience: null,
                    claims: new Claim[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("FirstName", user.FirstName),
                        new Claim("Email", user.Email),
                        new Claim("IsAdmin", user.IsAdmin.ToString())
                    },
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(1)
                    )
                );

            return Handler.WriteToken(jwtSecurityToken);
        }

        public User DecodeToken(string token)
        {
            User user = null;
            token = token.Replace("Bearer ", "");
            JwtSecurityToken jwtSecurityToken = Handler.ReadJwtToken(token);
            if(jwtSecurityToken.ValidFrom <= DateTime.Now && jwtSecurityToken.ValidTo >= DateTime.Now)
            {
                JwtPayload payload = jwtSecurityToken.Payload;
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payload));

                if(token == test)
                {
                    payload.TryGetValue("Id", out object id);
                    payload.TryGetValue("LastName", out object lastName);
                    payload.TryGetValue("FirstName", out object firstName);
                    payload.TryGetValue("Email", out object email);
                    payload.TryGetValue("IsAdmin", out object IsAdmin);
                    user = new User()
                    {
                        Id = int.Parse((string)id),
                        LastName = (string)lastName,
                        FirstName = (string)firstName,
                        Email = (string)email,
                        IsAdmin = bool.Parse((string)IsAdmin)
                    };
                }
            }

            return user;
        }
    }
}