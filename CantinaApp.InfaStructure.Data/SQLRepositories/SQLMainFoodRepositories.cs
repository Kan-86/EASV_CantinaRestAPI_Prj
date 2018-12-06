using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CantinaApp.InfaStructure.Data.SQLRepositories
{
    public class SQLMainFoodRepositories : IMainFoodRepositories
    {
        readonly CantinaAppContext _ctx;

        public SQLMainFoodRepositories(CantinaAppContext ctx)
        {
            _ctx = ctx;
        }

        public int Count()
        {
            return _ctx.MainFood.Count();
        }

        public MainFood CreateMainFood(MainFood mainFood)
        {
            _ctx.Attach(mainFood).State = EntityState.Added;
            _ctx.SaveChanges();
            return mainFood;
        }

        public MainFood GetMainFoodByID(int id)
        {
            return _ctx.MainFood.FirstOrDefault(m => m.Id == id);
        }

        public MainFood ReadById(int id)
        {
            return _ctx.MainFood
                .FirstOrDefault(c => c.Id == id);
        }

        public MainFood ReadByIdIncludeIngredients(int id)
        {
            return _ctx.MainFood
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<MainFood> ReadMainFood(Filter filter = null)
        {
            if (filter == null)
            {
                return _ctx.MainFood;
            }
            return _ctx.MainFood.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public MainFood UpdateMainFood(MainFood foodUpdate)
        {
            _ctx.Attach(foodUpdate).State = EntityState.Modified;
            _ctx.Entry(foodUpdate).Reference(o => o.MainFoodName).IsModified = true;
            _ctx.SaveChanges();
            return foodUpdate;
        }

        public MainFood DeleteMainFood(int id)
        {
            var mFoodDelete = _ctx.MainFood.ToList().FirstOrDefault(b => b.Id == id);
            _ctx.MainFood.Remove(mFoodDelete);
            _ctx.SaveChanges();
            return mFoodDelete;
        }
    }
}
