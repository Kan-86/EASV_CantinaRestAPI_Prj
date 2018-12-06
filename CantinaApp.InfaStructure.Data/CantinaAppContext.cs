using CantinaApp.Core.Entity.Entities;
using CantinaApp.Core.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.InfaStructure.Data
{
    public class CantinaAppContext: DbContext
    {
        public CantinaAppContext(DbContextOptions<CantinaAppContext> opt) : base(opt)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Overrides the modelbuilder
            base.OnModelCreating(modelBuilder);

            //Main Food can have many allergens
            modelBuilder.Entity<RecipeLine>()
                .HasKey(a => new { a.MainFoodId , a.IngredientsId });
            //Main Food can only have one Icon
            modelBuilder.Entity<RecipeLine>()
                .HasOne(a => a.MainFoodType)
                .WithMany(m => m.RecipeLines)
                .HasForeignKey(rl => rl.MainFoodId);
            //Ingredientsd can only have one Icon


            modelBuilder.Entity<RecipeLine>()
                .HasOne(a => a.IngredientsType)
                .WithMany(m => m.RecipeLines)
                .HasForeignKey(rl => rl.IngredientsId);

        }
        //Tables
        public DbSet<Users> User { get; set; }
        public DbSet<MainFood> MainFood { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<SpecialOffers> SpecialOffers { get; set; }
        public DbSet<Allergens> Allergen { get; set; }
        public DbSet<MOTD> MOTD { get; set; }
    }
}
