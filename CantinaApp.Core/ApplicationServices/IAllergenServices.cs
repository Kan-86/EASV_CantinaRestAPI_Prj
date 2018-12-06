using CantinaApp.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.ApplicationServices
{
    public interface IAllergenServices
    {
        List<Allergens> GetAllergens();

        Allergens AddAllergen(Allergens allergen);

        Allergens DeleteAllergen(int id);

        Allergens FindAllergenId(int id);

        Allergens UpdateAllergen(Allergens allergenUpdate);
    }
}
