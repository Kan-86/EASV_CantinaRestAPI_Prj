using CantinaApp.Core.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.DomainServices
{
    public interface IUserRepositories<T>
    {
        Users GetUserByID(int id);

        IEnumerable<Users> ReadAllUsers();

        Users CreateUsers(Users user);

        Users DeleteUsers(int id);

        Users UpdateUser(Users userUpdate);
    }
}
