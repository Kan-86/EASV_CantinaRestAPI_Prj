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
            _ctx.Attach(ingredient).State = EntityState.Added;
            _ctx.SaveChanges();
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

        public Ingredients ReadByIdIncludeFoodIcon(int id)
        {
            return _ctx.Ingredients
                 .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Ingredients> ReadIngredients()
        {
            return _ctx.Ingredients;
        }

        public Ingredients UpdateIngredient(Ingredients ingredientUpdate)
        {
            _ctx.Ingredients.Update(ingredientUpdate);
            _ctx.SaveChanges();
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
