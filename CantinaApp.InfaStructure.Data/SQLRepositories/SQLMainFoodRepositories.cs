using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CantinaApp.InfaStructure.Data.SQLRepositories
{
    public class SQLMainFoodRepositories : IMainFoodRepositories
    {
        readonly CantinaAppContext _ctx;

        public SQLMainFoodRepositories(CantinaAppContext ctx)
        {
            _ctx = ctx;
        }

        public MainFood CreateMainFood(MainFood mainFood)
        {
            _ctx.Attach(mainFood).State = EntityState.Added;
            _ctx.SaveChanges();
            return mainFood;
        }

        public IEnumerable<MainFood> ReadMainFood()
        {

            var query = _ctx.Set<MainFood>();


            

                return _ctx.MainFood
                    .Include(c => c.AllergensInMenu).
                    ThenInclude(x => x.AllergenType)
                    .Include(c => c.RecipeLines)
                    .ThenInclude(c => c.IngredientsType)
                     ;

          
        }

        public MainFood UpdateMainFood(MainFood foodUpdate)
        {
            List<RecipeLine> newRecipeLines= new List<RecipeLine>();
            List<AllergensInMenu> newAllegensMenu = new List<AllergensInMenu>();
            if ( foodUpdate.RecipeLines != null)
            {
            newRecipeLines = new List<RecipeLine>(foodUpdate.RecipeLines);
            }
            if ( foodUpdate.AllergensInMenu != null)
            { 
             newAllegensMenu = new List<AllergensInMenu>(foodUpdate.AllergensInMenu);
            }

            _ctx.Attach(foodUpdate).State = EntityState.Modified;

            
           
            _ctx.RecipeLine.RemoveRange(
                _ctx.RecipeLine.Where(m => m.MainFoodId == foodUpdate.Id)
            );

            _ctx.AllergensInMenu.RemoveRange(
                _ctx.AllergensInMenu.Where(ol => ol.MainFoodId == foodUpdate.Id)
            );
            
            foreach (var RL in newRecipeLines)

            {
                _ctx.Entry(RL).State = EntityState.Added;
            }

            foreach (var AM in newAllegensMenu)
            {
                _ctx.Entry(AM).State = EntityState.Added;
            }
            // Save it

            _ctx.SaveChanges();
            return foodUpdate;
        }

        public MainFood DeleteMainFood(int id)
        {
            var mFoodDelete = _ctx.MainFood.ToList().FirstOrDefault(b => b.Id == id);
            _ctx.MainFood.Remove(mFoodDelete);
            _ctx.SaveChanges();
            return mFoodDelete;
        }

        public MainFood ReadByIdIncludeRecipAlrg(int id)
        {
            return _ctx.MainFood.
                    Include(c=> c.AllergensInMenu).
                    ThenInclude(x=> x.AllergenType)
                    .Include(c => c.RecipeLines)
                    .ThenInclude(c => c.IngredientsType)
                    .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<MainFood> ReadTodayMenues(DateTime date)
        {
            return _ctx.MainFood.
                    Include(c=> c.AllergensInMenu).
                    ThenInclude(x=> x.AllergenType)
                    .Include(c => c.RecipeLines)
                    .ThenInclude(c => c.IngredientsType)
                    .Where(c => c.FoodDate.Date == date.Date);

        }


    }
}
