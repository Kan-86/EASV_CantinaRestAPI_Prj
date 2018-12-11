using CantinaApp.Core.Entity.Models;
using System.Collections.Generic;

namespace CantinaApp.Core.DomainServices
{
    public interface IUserRepositories
    {
        IEnumerable<Users> ReadAllUsers();

        Users CreateUsers(Users user);

        Users DeleteUsers(int id);

        Users UpdateUser(Users userUpdate);
    }
}
