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
            return _ingredientsRepo.CreateIngredient(ingredient);
        }

        public Ingredients DeleteIngredient(int id)
        {
            return _ingredientsRepo.DeleteIngredient(id);
        }

        public Ingredients FindIngredientIdIncludeMainFood(int id)
        {
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
