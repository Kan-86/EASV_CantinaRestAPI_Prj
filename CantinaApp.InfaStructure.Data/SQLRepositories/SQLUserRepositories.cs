using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CantinaApp.InfaStructure.Data.SQLRepositories
{
    public class SQLUserRepositories : IUserRepositories
    {

        private readonly CantinaAppContext _ctx;

        public SQLUserRepositories(CantinaAppContext context)
        {
            _ctx = context;
        }

        public void Add(Users user)
        {

            _ctx.Users.Add(entity);
            _ctx.SaveChanges();
        }

        public Users CreateUsers(Users user)
        {
            _ctx.Attach(user).State = EntityState.Added;
            _ctx.SaveChanges();
            return user;
        }

        public Users DeleteUsers(int id)
        {
            var userToDelete = _ctx.Users.ToList().FirstOrDefault(b => b.Id == id);
            _ctx.Users.Remove(userToDelete);
            _ctx.SaveChanges();
            return userToDelete;
        }

        public IEnumerable<Users> ReadAllUsers()
        {
            return _ctx.Users;
        }

        public Users UpdateUser(Users userUpdate)
        {
            _ctx.Attach(userUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return userUpdate;
        }
    }
}
