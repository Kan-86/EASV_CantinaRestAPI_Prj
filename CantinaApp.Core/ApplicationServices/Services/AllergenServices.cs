using System;
using System.Collections.Generic;
using System.Linq;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;

namespace CantinaApp.Core.ApplicationServices.Services
{
    public class AllergenServices : IAllergenServices
    {
        readonly IAllergensRepositories _allergensRepo;

        public AllergenServices(IAllergensRepositories allergensRepo)
        {
            _allergensRepo = allergensRepo;
        }

        public Allergens AddAllergen(Allergens allergen)
        {
            if (allergen.AllergenType == null)
            {
                throw new ArgumentException("You need to add a name for the allergen");
            }
            
            return _allergensRepo.CreateAllergen(allergen);
        }

        public Allergens DeleteAllergen(int id)
        {  if (id <1)
            {
                throw new ArgumentException("Íd need to be higher than 0");
            }
            return _allergensRepo.DeleteAllergen(id);
        }

        public Allergens FindAllergenId(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("Íd need to be higher than 0");
            }
            return _allergensRepo.GetAllergenByID(id);
        }

        public List<Allergens> GetAllergens()
        {
            return _allergensRepo.ReadAllergen().ToList();
        }

        public Allergens UpdateAllergen(Allergens allergenUpdate)
        {
            if (allergenUpdate.Id < 1)
            {
                throw new ArgumentException("Íd need to be higher than 0");
            }
            if (allergenUpdate.AllergenType == null)
            {
                throw new ArgumentException("You need to add a name for the allergen");
            }
            return _allergensRepo.UpdateAllergen(allergenUpdate);
        }
    }
}
