using CantinaApp.Core.Entity.Entities;
using System.Collections.Generic;

namespace CantinaApp.Core.ApplicationServices
{
    public interface IIngredientsServices
    {
        List<Ingredients> GetIngredients();

        Ingredients AddIngredient(Ingredients ingredient);

        Ingredients DeleteIngredient(int id);

        Ingredients FindIngredientIdIncludeMainFood(int id);

        Ingredients UpdateIngredient(Ingredients ingredientUpdate);
    }
}
