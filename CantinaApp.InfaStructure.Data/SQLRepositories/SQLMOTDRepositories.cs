using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CantinaApp.InfaStructure.Data.SQLRepositories
{
    public class SQLMOTDRepositories : IMOTDRepositories
    {
        private readonly CantinaAppContext _ctx;

        public SQLMOTDRepositories(CantinaAppContext ctx)
        {
            _ctx = ctx;
        }

        public MOTD CreateMOTD(MOTD motd)
        {
            _ctx.Attach(motd).State = EntityState.Added;
            _ctx.SaveChanges();
            return motd;
        }

        public MOTD DeleteMOTD(int id)
        {

            var MOTDDeleted = _ctx.MOTD.ToList().FirstOrDefault(b => b.Id == id);
            _ctx.MOTD.Remove(MOTDDeleted);
            _ctx.SaveChanges();
            return MOTDDeleted;
        }

        public IEnumerable<MOTD> ReadMOTD()
        {
            return _ctx.MOTD;
        }

        public MOTD UpdateMOTD(MOTD motdUpdate)
        {
            _ctx.Attach(motdUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return motdUpdate;
        }
    }
}
