using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CantinaApp.InfaStructure.Data.SQLRepositories
{
    public class SQLUserRepositories : IUserRepositories<Users>
    {

        private readonly CantinaAppContext db;

        public SQLUserRepositories(CantinaAppContext context)
        {
            db = context;
        }

        public void Add(Users entity)
        {
            db.UserFromCantine.Add(entity);
            db.SaveChanges();
        }

        public Users CreateUsers(Users user)
        {
            throw new NotImplementedException();
        }

        public Users DeleteUsers(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Users entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Users Get(long id)
        {
            return db.UserFromCantine.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Users> GetAll()
        {
            return db.UserFromCantine.ToList();
        }

        public Users GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> ReadAllUsers()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            var item = db.UserFromCantine.FirstOrDefault(b => b.Id == id);
            db.UserFromCantine.Remove(item);
            db.SaveChanges();
        }

        public Users UpdateUser(Users userUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
