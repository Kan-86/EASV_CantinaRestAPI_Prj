using System;
using System.Collections.Generic;
using System.Text;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Models;

namespace CantinaApp.Core.ApplicationServices.Services
{
    public class UsersServices : IUsersServices
    {
        readonly IUserRepositories<Users> _userRepo;

        public UsersServices(IUserRepositories<Users> userRepo)
        {
            _userRepo = userRepo;
        }

        public Users AddUsers(Users user)
        {
            return _userRepo.CreateUsers(user);
        }

        public Users DeleteMOTD(int id)
        {
            throw new NotImplementedException();
        }

        public Users FindUsersId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Users GetUsersInstance()
        {
            throw new NotImplementedException();
        }

        public Users UpdateUsers(Users userUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
