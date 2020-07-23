using Models.Common.Intefaces;
using Models.Global.Entities;
using Models.Global.Services.Extensions;
using System;
using System.Data.SqlClient;
using System.Linq;
using Tools.Databases;

namespace Models.Global.Services
{
    public class AuthRepository : IAuthRepository<User>
    {
        private Connection _connection;

        public AuthRepository()
        {
            _connection = new Connection(new ConnectionInfo(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestContact;Integrated Security=True;"), SqlClientFactory.Instance);
        }

        public User Login(string login, string passwd)
        {
            Command command = new Command("Login", true);
            command.AddParameter("Email", login);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, (dr) => dr.ToUser()).SingleOrDefault();
        }

        public void Register(User user)
        {
            Command command = new Command("Register", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);

            _connection.ExecuteNonQuery(command);
        }
    }
}
