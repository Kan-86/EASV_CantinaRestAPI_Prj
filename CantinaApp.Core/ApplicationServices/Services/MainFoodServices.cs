using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;

namespace CantinaApp.Core.ApplicationServices.Services
{
    public class MainFoodServices : IMainFoodServices
    {
        readonly IMainFoodRepositories _mainFoodRepo;
        readonly IIngredientsRepositories _ingredientsRepo;

        public MainFoodServices(IMainFoodRepositories mainFoodRepo, 
            IIngredientsRepositories ingredientsRepo)
        {
            _mainFoodRepo = mainFoodRepo;
            _ingredientsRepo = ingredientsRepo;
        }

        public MainFood AddMainFood(MainFood mainFood)
        {
            if (string.IsNullOrEmpty(mainFood.MainFoodName))
            {
                throw new InvalidOperationException("Main Food needs a name.");
            }
            return _mainFoodRepo.CreateMainFood(mainFood);
        }

        public MainFood DeleteMainFood(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException("Main Food Id needs to be larger than 1.");
            }
            return _mainFoodRepo.DeleteMainFood(id);
        }

        public MainFood FindMainFoodId(int id)
        {
            return _mainFoodRepo.ReadById(id);
        }

        public MainFood FindMainFoodIdIncludeIngredients(int id)
        {
            var mFood = _mainFoodRepo.ReadByIdIncludeIngredients(id);
            return mFood;
        }

        public List<MainFood> GetFilteredMainFood(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("Current page and Items page must be zero or more");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _mainFoodRepo.Count())
            {
                throw new InvalidDataException("Index out of bounds, Curret page is too high");
            }
            return _mainFoodRepo.ReadMainFood(filter).ToList();
        }

        public List<MainFood> GetMainFood()
        {
            return _mainFoodRepo.ReadMainFood().ToList();
        }

        public MainFood UpdateMainFood(MainFood mainFoodUpdate)
        {
            return _mainFoodRepo.UpdateMainFood(mainFoodUpdate);
        }
    }
}
