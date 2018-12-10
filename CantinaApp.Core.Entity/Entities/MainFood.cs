using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.Entity.Entities
{
    public class MainFood
    {
        public int Id { get; set; }
        public String MainFoodName { get; set; }
        public List<RecipeLine> RecipeLines { get; set; }
        public List<AllergensInMenu> AllergensInMenu { get; set; }
        public DateTime FoodDate { get; set; }
        public int FoodIconId { get; set; }
    }
}
