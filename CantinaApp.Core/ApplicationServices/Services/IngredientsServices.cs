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
            if (ingredient.IngredientName == null)
            {
                throw new ArgumentException("Ingredient needs a name");
            }
            if (ingredient.RecipeLines == null)
            {
                throw new ArgumentException("You need to have a connection between food and ingredients (RecipeLines)");
            }
            else{
                foreach (var item in ingredient.RecipeLines)
                {
                    if (item.IngredientsId < 1)
                    {
                        throw new ArgumentException("RecipLines IngredientsId need to be higher than 1");
                    }
                    if (item.MainFoodId < 1)
                    {
                        throw new ArgumentException("RecipLines IngredientsId need to be higher than 1");
                    }
                }
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
            if (ingredientUpdate.IngredientName == null)
            {
                throw new InvalidOperationException("Ingredient need a name");
            }
            if (ingredientUpdate.RecipeLines == null)
            {
                throw new InvalidOperationException("You need to have \"RecipsLines\" Connection between food and ingredients ");
            }
            else
            {
                foreach (var item in ingredientUpdate.RecipeLines)
                {
                    if (item.IngredientsId < 1)
                    {
                        throw new InvalidOperationException("RecipLines IngredientsId need to be higher than 1");
                    }
                    if (item.MainFoodId < 1)
                    {
                        throw new InvalidOperationException("RecipLines IngredientsId need to be higher than 1");
                    }
                }

            }
        
            return _ingredientsRepo.UpdateIngredient(ingredientUpdate);
        }
    }
}
