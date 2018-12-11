using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;

namespace CantinaApp.Core.ApplicationServices.Services
{
    public class IngredientsServices : IIngredientsServices
    {
        readonly IIngredientsRepositories _ingredientsRepo;

        public IngredientsServices(IIngredientsRepositories ingredientsRepo)
        {
            _ingredientsRepo = ingredientsRepo;
        }

        public Ingredients AddIngredient(Ingredients ingredient)
        {
            if (string.IsNullOrEmpty(ingredient.IngredientName))
            {
                throw new ArgumentException("The ingredient needs a name.");
            }
            return _ingredientsRepo.CreateIngredient(ingredient);
        }

        public Ingredients DeleteIngredient(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID requires to be greater than 0.");
            }
            return _ingredientsRepo.DeleteIngredient(id);
        }

        public Ingredients FindIngredientIdIncludeMainFood(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID requires to be greater than 0.");
            }
            return _ingredientsRepo.ReadByIdIncludeAllergens(id);
        }

        public List<Ingredients> GetIngredients()
        {
            return _ingredientsRepo.ReadIngredients().ToList();
        }

        public Ingredients UpdateIngredient(Ingredients ingredientUpdate)
        {
            return _ingredientsRepo.UpdateIngredient(ingredientUpdate);
        }
    }
}
