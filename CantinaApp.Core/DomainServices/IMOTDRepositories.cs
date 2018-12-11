using CantinaApp.Core.Entity.Entities;
using System.Collections.Generic;

namespace CantinaApp.Core.DomainServices
{
    public interface IMOTDRepositories
    {
        IEnumerable<MOTD> ReadMOTD();

        MOTD CreateMOTD(MOTD motd);

        MOTD GetMOTDById(int id);

        MOTD DeleteMOTD(int id);
        
        MOTD UpdateMOTD(MOTD motdUpdate);
    }
}
