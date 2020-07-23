using System;

namespace Models.Client.Entities
{
    public class User
    {   
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; internal set; }

        public User(string lastName, string firstName, string email, string passwd)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
        }

        internal User(int id, string lastName, string firstName, string email, string token, bool isAdmin)
            : this (lastName, firstName, email, null)
        {
            Id = id;
            Token = token;
            IsAdmin = isAdmin;
        }
    }
}
