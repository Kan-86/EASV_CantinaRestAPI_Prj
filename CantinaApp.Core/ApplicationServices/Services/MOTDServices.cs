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
            return _MOTDRepo.CreateMOTD(motd);
        }

        public MOTD DeleteMOTD(int id)
        {
            return _MOTDRepo.DeleteMOTD(id);
        }
        
        public List<MOTD> GetMOTDs()
        {
            return _MOTDRepo.ReadMOTD().ToList();
        }

        public MOTD GetMOTDById(int id)
        {
            return _MOTDRepo.ReadMOTD().ToList().FirstOrDefault(motd => motd.Id == id);
        }

        public MOTD UpdateMOTD(MOTD motdUpdate)
        {
          return _MOTDRepo.UpdateMOTD(motdUpdate); 

        }
    }
}
