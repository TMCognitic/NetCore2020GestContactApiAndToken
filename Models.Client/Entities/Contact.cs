using System;

namespace Models.Client.Entities
{
    public class Contact
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName
        {
            get => $"{LastName} {FirstName}";
        }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; private set; }

        public Contact(string lastName, string firstName, string email, int userId, string phone = null)
        {
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(lastName));
            UserId = userId;
            Phone = phone;
        }

        internal Contact(int id, string lastName, string firstName, string email, string phone, int userId)
            : this (lastName, firstName, email, userId, phone)
        {
            Id = id;
        }
    }
}
