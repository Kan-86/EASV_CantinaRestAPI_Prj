using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.Entity.Entities
{
    public class RecipeLine
    {
        public int MainFoodId { get; set; }
        public MainFood MainFoodType { get; set; }
        public int IngredientsId { get; set; }
        public Ingredients IngredientsType { get; set; }
    }
}
