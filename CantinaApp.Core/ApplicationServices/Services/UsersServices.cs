using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Models;

namespace CantinaApp.Core.ApplicationServices.Services
{
    public class UsersServices : IUsersServices
    {
        readonly DomainServices.IUserRepositories _userRepo;

        public UsersServices(DomainServices.IUserRepositories userRepo)
        {
            _userRepo = userRepo;
        }

        public Users AddUsers(Users user)
        {
            if (user.Username == null)
            {
                throw new ArgumentException("You need to have an username");
            }
            return _userRepo.CreateUsers(user);
        }

        public Users DeleteUser(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException("ID requires to be greater than 0.");
            }
            return _userRepo.DeleteUsers(id);
        }

        public Users FindUsersId(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException("ID requires to be greater than 0.");
            }
            return _userRepo.ReadAllUsers().ToList().FirstOrDefault(motd => motd.Id == id);
        }

        public List<Users> GetUsers()
        {
            return _userRepo.ReadAllUsers().ToList();
        }

        public Users UpdateUsers(Users userUpdate)
        {
            if (userUpdate.Id < 1)
            {
                throw new ArgumentException("You need to have an higher id than 0");
            }
            if (userUpdate.Username == null)
            {
                throw new ArgumentException("You need to have an username");
            }
            return _userRepo.UpdateUser(userUpdate);
        }
    }
}
