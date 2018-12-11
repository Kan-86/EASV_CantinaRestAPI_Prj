using CantinaApp.Core.Entity.Entities;
using System.Collections.Generic;

namespace CantinaApp.Core.ApplicationServices
{
    public interface IMOTDServices
    {
        MOTD GetMOTDById(int id);

        List<MOTD> GetMOTDs();

        MOTD AddMOTD(MOTD motd);

        MOTD DeleteMOTD(int id);

        MOTD UpdateMOTD(MOTD motdUpdate);
    }
}
