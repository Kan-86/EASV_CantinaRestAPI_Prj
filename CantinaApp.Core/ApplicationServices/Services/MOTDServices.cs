using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;

namespace CantinaApp.Core.ApplicationServices.Services
{
    public class MOTDServices : IMOTDServices
    {
        readonly IMOTDRepositories _MOTDRepo;

        public MOTDServices(IMOTDRepositories MOTDRepo)
        {
            _MOTDRepo = MOTDRepo;
        }

        public MOTD AddMOTD(MOTD motd)
        {
            if (motd.TipOfTheDay == null)
            {
                throw new ArgumentException("You need to write a message");
            }
            return _MOTDRepo.CreateMOTD(motd);
        }

        public MOTD DeleteMOTD(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException("ID requires to be greater than 0.");
            }
            return _MOTDRepo.DeleteMOTD(id);
        }
        
        public List<MOTD> GetMOTDs()
        {
            return _MOTDRepo.ReadMOTD().ToList();
        }

        public MOTD GetMOTDById(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException("ID requires to be greater than 0.");
            }
            return _MOTDRepo.ReadMOTD().ToList().FirstOrDefault(motd => motd.Id == id);
        }

        public MOTD UpdateMOTD(MOTD motdUpdate)
        {
            if (motdUpdate.Id < 1)
            {
                throw new ArgumentException("You need to have an higher id than 0");
            }
            return _MOTDRepo.UpdateMOTD(motdUpdate); 

        }
    }
}
