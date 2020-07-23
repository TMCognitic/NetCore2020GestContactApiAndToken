using G = Models.Global.Entities;
using Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Client.Mappers
{
    internal static class EntitiesMappers
    {
        internal static Contact ToClient(this G.Contact entity)
        {
            return new Contact(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.Phone, entity.UserId);
        }

        internal static G.Contact ToGlobal(this Contact entity)
        {
            return new G.Contact() { Id = entity.Id, LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Phone = entity.Phone, UserId = entity.UserId };
        }

        internal static User ToClient(this G.User entity)
        {
            return new User(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.Token, entity.IsAdmin);
        }

        internal static G.User ToGlobal(this User entity)
        {
            return new G.User() { Id = entity.Id, LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Passwd = entity.Passwd, IsAdmin = entity.IsAdmin, Token = entity.Token };
        }
    }
}
