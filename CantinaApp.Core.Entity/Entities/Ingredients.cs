using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.Entity.Entities
{
    public class Ingredients
    {
        public int Id { get; set; }
        public String IngredientName{ get; set; }
        public int FoodIconId { get; set; }
        public Allergens AllergenType { get; set; }
        public List<RecipeLine> RecipeLines { get; set; }
    }
}
