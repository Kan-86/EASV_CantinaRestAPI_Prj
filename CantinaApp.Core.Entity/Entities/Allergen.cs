using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.Entity.Entities
{
    public class Allergen
    {
        public int Id { get; set; }
        public String AllergenType { get; set; }
        public FoodIcon FoodIconType{ get; set; }
        public MainFood MainFoodType { get; set; }
    }
}
