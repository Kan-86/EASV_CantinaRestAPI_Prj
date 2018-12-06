using CantinaApp.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.DomainServices
{
    public interface IIngredientsRepositories
    {
        Ingredients GetIngredientsByID(int id);

        IEnumerable<Ingredients> ReadIngredients();

        Ingredients CreateIngredient(Ingredients ingredient);

        Ingredients DeleteIngredient(int id);

        Ingredients ReadById(int id);

        Ingredients UpdateIngredient(Ingredients ingredientUpdate);

        Ingredients ReadByIdIncludeAllergens(int id);
    }
}
