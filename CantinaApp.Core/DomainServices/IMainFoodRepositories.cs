using CantinaApp.Core.DomainServices.List;
using CantinaApp.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.DomainServices
{
    public interface IMainFoodRepositories
    {

        IEnumerable<MainFood> ReadMainFood(/*Filter filter = null*/);

        MainFood CreateMainFood(MainFood mainFood);

        MainFood DeleteMainFood(int id);

        MainFood UpdateMainFood(MainFood foodUpdate);

        MainFood ReadByIdIncludeRecipAlrg(int id);

        int Count();  
    }
}
