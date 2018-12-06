using CantinaApp.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.DomainServices
{
    public interface IAllergensRepositories
    {
        Allergens GeAllergenByID(int id);

        IEnumerable<Allergens> ReadMAllergen();

        Allergens CreateAllergen(Allergens allergen);

        Allergens DeleteAllergen(int id);

        Allergens ReadById(int id);

        Allergens UpdateAllergen(Allergens allergenUpdate);
    }
}
