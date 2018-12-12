using CantinaApp.Core.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.ApplicationServices
{
    public interface IUsersServices
    {
        List<Users> GetUsers();

        Users AddUsers(Users motd);

        Users DeleteUser(int id);

        Users FindUsersId(int id);

        Users UpdateUsers(Users userUpdate);
    }
}
