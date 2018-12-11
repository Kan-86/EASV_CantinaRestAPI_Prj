using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.Entity.Entities
{
    public class AllergensInMenu
    {
        public int MainFoodId { get; set; }
        public MainFood MainFoodType { get; set; }
        public int AllergenID { get; set; }
        public Allergens AllergenType { get; set; }
    }
}
