using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                throw new InvalidOperationException("You need to add a name for the allergen");
            }
            
            return _allergensRepo.CreateAllergen(allergen);
        }

        public Allergens DeleteAllergen(int id)
        {
            return _allergensRepo.DeleteAllergen(id);
        }

        public Allergens FindAllergenId(int id)
        {
            return _allergensRepo.ReadById(id);
        }

        public List<Allergens> GetAllergens()
        {
            return _allergensRepo.ReadMAllergen().ToList();
        }

        public Allergens UpdateAllergen(Allergens allergenUpdate)
        {
            return _allergensRepo.UpdateAllergen(allergenUpdate);
        }
    }
}
