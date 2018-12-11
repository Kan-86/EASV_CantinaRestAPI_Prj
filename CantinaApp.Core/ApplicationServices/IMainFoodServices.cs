﻿using CantinaApp.Core.DomainServices.List;
using CantinaApp.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.ApplicationServices
{
    public interface IMainFoodServices
    {
        IEnumerable<MainFood> GetMainFood();

        MainFood AddMainFood(MainFood mainFood);

        MainFood DeleteMainFood(int id);

        MainFood FindMainFoodIdIncludeRecipAlrg(int id);

        MainFood UpdateMainFood(MainFood mainFoodUpdate);
    }
}
