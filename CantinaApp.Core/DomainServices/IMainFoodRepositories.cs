using CantinaApp.Core.Entity.Entities;
using System.Collections.Generic;

namespace CantinaApp.Core.DomainServices
{
    public interface IMainFoodRepositories
    {

        IEnumerable<MainFood> ReadMainFood(Filter filter = null);

        MainFood CreateMainFood(MainFood mainFood);

        MainFood DeleteMainFood(int id);

        MainFood UpdateMainFood(MainFood foodUpdate);

        MainFood ReadByIdIncludeRecipAlrg(int id);

        IEnumerable<MainFood> ReadTodayMenues(DateTime date);

        int Count();  
    }
}
