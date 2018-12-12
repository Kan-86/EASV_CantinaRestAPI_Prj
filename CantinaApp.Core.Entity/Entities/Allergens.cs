using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.Entity.Entities
{
    public class Allergens
    {
        public int Id { get; set; }
        public string AllergenType { get; set; }
        public List<AllergensInMenu> AllergensInMenu { get; set; }
    }
}
