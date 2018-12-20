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
            
            //Many to many Menu-Ingredients
            modelBuilder.Entity<RecipeLine>()
                .HasKey(a => new {
                    a.MainFoodId,
                    a.IngredientsId });
            modelBuilder.Entity<RecipeLine>()
                .HasOne(a => a.MainFoodType)
                .WithMany(m => m.RecipeLines)
                .HasForeignKey(rl => rl.MainFoodId);
            modelBuilder.Entity<RecipeLine>()
                .HasOne(a => a.IngredientsType)
                .WithMany(m => m.RecipeLines)
                .HasForeignKey(rl => rl.IngredientsId);

            //Many to many menu-allergens
            modelBuilder.Entity<AllergensInMenu>()
                .HasKey(a => new {
                    a.MainFoodId,
                    a.AllergenID
                });
            modelBuilder.Entity<AllergensInMenu>()
                .HasOne(a => a.MainFoodType)
                .WithMany(m => m.AllergensInMenu)
                .HasForeignKey(rl => rl.MainFoodId);
            modelBuilder.Entity<AllergensInMenu>()
                .HasOne(a => a.AllergenType)
                .WithMany(m => m.AllergensInMenu)
                .HasForeignKey(rl => rl.AllergenID);
        }
        //Tables
        public DbSet<Users> Users { get; set; }
        public DbSet<MainFood> MainFood { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<RecipeLine> RecipeLine { get; set; }
        public DbSet<AllergensInMenu> AllergensInMenu { get; set; }
        public DbSet<SpecialOffers> SpecialOffers { get; set; }
        public DbSet<Allergens> Allergen { get; set; }
        public DbSet<MOTD> MOTD { get; set; }
    }
}
