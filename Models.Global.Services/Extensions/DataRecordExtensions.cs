using Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models.Global.Services.Extensions
{
    //Mappers
    internal static class DataRecordExtensions
    {
        internal static Contact ToContact(this IDataRecord dataRecord)
        {
            return new Contact() { Id = (int)dataRecord["Id"], LastName = (string)dataRecord["LastName"], FirstName = (string)dataRecord["FirstName"], Email = (string)dataRecord["Email"], Phone = (dataRecord["Phone"] is DBNull) ? null : (string)dataRecord["Phone"], UserId = (int)dataRecord["UserId"] };
        }

        internal static User ToUser(this IDataRecord dataRecord)
        {
            return new User() { Id = (int)dataRecord["Id"], LastName = (string)dataRecord["LastName"], FirstName = (string)dataRecord["FirstName"], Email = (string)dataRecord["Email"], IsAdmin = (bool)dataRecord["IsAdmin"] };
        }
    }
}
