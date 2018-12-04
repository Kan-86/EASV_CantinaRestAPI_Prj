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


        }
        //Tables
        public DbSet<Users> User { get; set; }
        public DbSet<MainFood> MainFood { get; set; }
        public DbSet<FoodIcon> FoodIcon { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Allergen> Allergen { get; set; }
        public DbSet<SpecialOffers> SpecialOffers { get; set; }
        public DbSet<MOTD> MOTD { get; set; }
    }
}
