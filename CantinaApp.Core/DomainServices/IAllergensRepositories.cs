using CantinaApp.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.DomainServices
{
    public interface IAllergensRepositories
    {
        Allergens GetAllergenByID(int id);

        IEnumerable<Allergens> ReadAllergen();

        Allergens CreateAllergen(Allergens allergen);

        Allergens DeleteAllergen(int id);

        Allergens UpdateAllergen(Allergens allergenUpdate);
    }
}
