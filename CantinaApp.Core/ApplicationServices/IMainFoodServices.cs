using CantinaApp.Core.Entity.Entities;
using System.Collections.Generic;

namespace CantinaApp.Core.ApplicationServices
{
    public interface IMainFoodServices
    {
        IEnumerable<MainFood> GetMainFood();

        MainFood AddMainFood(MainFood mainFood);

        MainFood DeleteMainFood(int id);

        MainFood FindMainFoodIdIncludeRecipAlrg(int id);

        MainFood UpdateMainFood(MainFood mainFoodUpdate);
        List<MainFood> GetFilteredMainFood(Filter filter);
        IEnumerable<MainFood> GetTodayFood(DateTime date);

    }
}
