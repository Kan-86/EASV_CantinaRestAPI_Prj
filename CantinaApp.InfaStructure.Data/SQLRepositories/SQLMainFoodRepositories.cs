using CantinaApp.Core.DomainServices;
using CantinaApp.Core.DomainServices.List;
using CantinaApp.Core.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CantinaApp.InfaStructure.Data.SQLRepositories
{
    public class SQLMainFoodRepositories : IMainFoodRepositories
    {
        readonly CantinaAppContext _ctx;

        public SQLMainFoodRepositories(CantinaAppContext ctx)
        {
            _ctx = ctx;
        }

        public int Count()
        {
            return _ctx.MainFood.Count();
        }

        public MainFood CreateMainFood(MainFood mainFood)
        {
            //Clone orderlines to new location in memory, so they are not overridden on Attach
            var newRecipeLines = new List<RecipeLine>(mainFood.RecipeLines);
            //Attach order so basic properties are updated
            _ctx.Attach(mainFood).State = EntityState.Added;
            //Remove all orderlines with updated order information
            _ctx.RecipeLine.RemoveRange(
                _ctx.RecipeLine.Where(ol => ol.MainFoodId == mainFood.Id)
            );
            //Add all orderlines with updated order information
            foreach (var ol in newRecipeLines)
            {
                _ctx.Entry(ol).State = EntityState.Added;
            }
            // Save it
            _ctx.SaveChanges();
            //Return it
            return mainFood;
        }

        public MainFood GetMainFoodByID(int id)
        {
            return _ctx.MainFood.FirstOrDefault(m => m.Id == id);
        }

        public MainFood ReadById(int id)
        {
            return _ctx.MainFood
                .FirstOrDefault(c => c.Id == id);
        }

        public ListMany<MainFood> ReadMainFood(Filter filter = null)
        {
            var query = _ctx.Set<MainFood>();

           
            if (filter == null)
            {
                return new ListMany<MainFood>()
                {
                    ListT = _ctx.MainFood.ToList()
                };
                
            }

            return new ListMany<MainFood>()
            {
                ListT = new List<MainFood>()
              
            };
        }

        public MainFood UpdateMainFood(MainFood foodUpdate)
        {

            //Clone orderlines to new location in memory, so they are not overridden on Attach
            var newRecipeLines = new List<RecipeLine>(foodUpdate.RecipeLines);
            //Attach order so basic properties are updated
            _ctx.Attach(foodUpdate).State = EntityState.Modified;
            //Remove all orderlines with updated order information
            _ctx.RecipeLine.RemoveRange(
                _ctx.RecipeLine.Where(ol => ol.MainFoodId == foodUpdate.Id)
            );
            //Add all orderlines with updated order information
            foreach (var ol in newRecipeLines)
            {
                _ctx.Entry(ol).State = EntityState.Added;
            }
            // Save it
            _ctx.SaveChanges();
            //Return it
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
            return _ctx.MainFood
                    .Include(c => c.RecipeLines)
                    .ThenInclude(c => c.IngredientsType)
                    .FirstOrDefault(c => c.Id == id);
        }
    }
}
