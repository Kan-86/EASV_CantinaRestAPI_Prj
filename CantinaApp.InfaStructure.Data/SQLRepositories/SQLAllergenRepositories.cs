using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CantinaApp.InfaStructure.Data.SQLRepositories
{
    public class SQLAllergenRepositories : IAllergensRepositories
    {
        readonly CantinaAppContext _ctx;

        public SQLAllergenRepositories(CantinaAppContext ctx)
        {
            _ctx = ctx;
        }

        public Allergens CreateAllergen(Allergens allergen)
        {
            //Clone allergensInMenu to new location in memory, so they are not overridden on Attach
            var newAllergenInMenu = new List<AllergensInMenu>(allergen.AllergensInMenu);
            //Attach ingredient so basic properties are updated
            _ctx.Attach(allergen).State = EntityState.Added;
            //Remove all recipelines with updated order information
            _ctx.AllergensInMenu.RemoveRange(
                _ctx.AllergensInMenu.Where(ol => ol.MainFoodId == allergen.Id)
            );
            //Add all orderlines with updated order information
            foreach (var ol in newAllergenInMenu)
            {
                _ctx.Entry(ol).State = EntityState.Added;
            }
            // Save it
            _ctx.SaveChanges();
            //Return it
            return allergen ;
        }

        public Allergens GetAllergenByID(int id)
        {
            return _ctx.Allergen.FirstOrDefault(m => m.Id == id);
        }

        public Allergens ReadById(int id)
        {
            return _ctx.Allergen
                        .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Allergens> ReadMAllergen()
        {
            return _ctx.Allergen;
        }

        public Allergens ReadyByIdIncludeFoodIcon(int id)
        {
            return _ctx.Allergen
                         .FirstOrDefault(o => o.Id == id);
        }

        public Allergens UpdateAllergen(Allergens allergenUpdate)
        {
            foreach (var item in _ctx.AllergensInMenu.ToList().Where(c => c.AllergenID == allergenUpdate.Id))
            {
                _ctx.AllergensInMenu.Remove(item);
            }

            //Clone allergens in menu to new location in memory, so they are not overridden on Attach
            var relation = new List<AllergensInMenu>(allergenUpdate.AllergensInMenu);
            //Attach A.I.M so basic properties are updated
            _ctx.Attach(allergenUpdate).State = EntityState.Modified;
            
            //Add all orderlines with updated order information

            foreach (var ol in relation)
            {

                _ctx.Entry(ol).State = EntityState.Added;
            }
            // Save it
            _ctx.SaveChanges();
            //Return it
            return allergenUpdate;
        }

        public Allergens DeleteAllergen(int id)
        {
            var alrgDelete = _ctx.Allergen.ToList().FirstOrDefault(b => b.Id == id);
            _ctx.Allergen.Remove(alrgDelete);
            _ctx.SaveChanges();
            return alrgDelete;
        }
    }
}
