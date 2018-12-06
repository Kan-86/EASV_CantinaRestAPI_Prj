using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CantinaApp.InfaStructure.Data.SQLRepositories
{
    public class SQLIngredientsRepositories : IIngredientsRepositories
    {
        readonly CantinaAppContext _ctx;

        public SQLIngredientsRepositories(CantinaAppContext ctx)
        {
            _ctx = ctx;
        }

        public Ingredients CreateIngredient(Ingredients ingredient)
        {
            //Clone orderlines to new location in memory, so they are not overridden on Attach
            var newRecipeLines = new List<RecipeLine>(ingredient.RecipeLines);
            //Attach order so basic properties are updated
            _ctx.Attach(ingredient).State = EntityState.Added;
            //Remove all orderlines with updated order information
            _ctx.RecipeLine.RemoveRange(
                _ctx.RecipeLine.Where(ol => ol.MainFoodId == ingredient.Id)
            );
            //Add all orderlines with updated order information
            foreach (var ol in newRecipeLines)
            {
                _ctx.Entry(ol).State = EntityState.Added;
            }
            // Save it
            _ctx.SaveChanges();
            //Return it
            return ingredient;
        }

        public Ingredients GetIngredientsByID(int id)
        {
            return _ctx.Ingredients.FirstOrDefault(m => m.Id == id);
        }

        public Ingredients ReadById(int id)
        {
            return _ctx.Ingredients
                .FirstOrDefault(c => c.Id == id);
        }

        public Ingredients ReadByIdIncludeAllergens(int id)
        {
            return _ctx.Ingredients
                    .Include(c => c.RecipeLines)
                    .ThenInclude(c => c.MainFoodType)
                    .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Ingredients> ReadIngredients()
        {
            return _ctx.Ingredients;
        }

        public Ingredients UpdateIngredient(Ingredients ingredientUpdate)
        {
            //Clone orderlines to new location in memory, so they are not overridden on Attach
            var newRecipeLines = new List<RecipeLine>(ingredientUpdate.RecipeLines);
            //Attach order so basic properties are updated
            _ctx.Attach(ingredientUpdate).State = EntityState.Modified;
            //Remove all orderlines with updated order information
            _ctx.RecipeLine.RemoveRange(
                _ctx.RecipeLine.Where(ol => ol.IngredientsId == ingredientUpdate.Id)
            );
            //Add all orderlines with updated order information
            foreach (var ol in newRecipeLines)
            {
                _ctx.Entry(ol).State = EntityState.Added;
            }
            // Save it
            _ctx.SaveChanges();
            //Return it
            return ingredientUpdate;
        }

        public Ingredients DeleteIngredient(int id)
        {
            var ingrDelete = _ctx.Ingredients.ToList().FirstOrDefault(b => b.Id == id);
            _ctx.Ingredients.Remove(ingrDelete);
            _ctx.SaveChanges();
            return ingrDelete;
        }
    }
}
