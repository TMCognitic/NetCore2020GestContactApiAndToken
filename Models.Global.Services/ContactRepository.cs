using Models.Global.Intefaces;
using Models.Global.Entities;
using Models.Global.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Tools.Databases;

namespace Models.Global.Services
{
    public class ContactRepository : IContactRepository<Contact>
    {
        private Connection _connection;

        public ContactRepository()
        {
            _connection = new Connection(new ConnectionInfo(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestContact;Integrated Security=True;"), SqlClientFactory.Instance);
        }

        public IEnumerable<Contact> Get(int userId)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, Phone, UserId From Contact where UserId = @UserId");
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, (dr) => dr.ToContact());
        }

        public Contact Get(int userId, int id)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, Phone, UserId From Contact where UserId = @UserId and Id = @Id");
            command.AddParameter("UserId", userId);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (dr) => dr.ToContact()).SingleOrDefault();
        }

        public Contact Insert(Contact entity)
        {
            Command command = new Command("insert into Contact(LastName, FirstName, Email, Phone, UserId) output inserted.Id values (@LastName, @FirstName, @Email, @Phone, @UserId)");
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Phone", entity.Phone);
            command.AddParameter("UserId", entity.UserId);
            entity.Id = (int)_connection.ExecuteScalar(command);
            return entity;
        }

        public bool Update(int id, Contact entity)
        {
            Command command = new Command("Update Contact Set LastName = @LastName, FirstName = @FirstName, Email = @Email, Phone = @Phone where Id = @Id And UserId = @UserId;");
            command.AddParameter("Id", id);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Phone", entity.Phone);
            command.AddParameter("UserId", entity.UserId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int userId, int id)
        {
            Command command = new Command("Delete From Contact where Id = @Id And UserId = @UserId;");
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
