using CantinaApp.Core.Entity.Entities;
using CantinaApp.Core.Entity.Models;
using EASV_CantinaRestAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.InfaStructure.Data
{
    public class DBInitializer
    {
        public IAuthenticationHelper authenticationHelper;

        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public static void SeedDb(CantinaAppContext ctx)
        {

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<Users> users = new List<Users>
            {
                new Users {
                    Username = "fabio",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = true
                },
                new Users {
                    Username = "jeppe",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = false
                }
            };

            var ingr = ctx.Ingredients.Add(new Ingredients()
            {
                IngredientName = "KasperBBQ Sauce",

            }).Entity;

            var mainFood = ctx.MainFood.Add(new MainFood()
            {
                MainFoodName = "SalsaFlamingoHamburger",
                FoodDate = DateTime.Today
            }).Entity;


            var mainFood1 = ctx.MainFood.Add(new MainFood()
            {
                MainFoodName = "PineAppleCoffeeSandwitch",
                FoodDate = DateTime.Today
            }).Entity;



            var ingr1 = ctx.Ingredients.Add(new Ingredients()
            {
                IngredientName = "Jacob and Sams Sauce",

            }).Entity;

            var spcl = ctx.SpecialOffers.Add(new SpecialOffers()
            {
                SpecialOfferName = "Danish Meatballs",
                OffersDate = DateTime.Today
            }).Entity;

            var motd = ctx.MOTD.Add(new MOTD()
            {
                TipOfTheDay = "One Dane per day, makes problems go away"
            }).Entity;

            var motd1 = ctx.MOTD.Add(new MOTD()
            {
                TipOfTheDay = "Why do Danes go out when they hear a thunderstorm? Because they think they are being photographed :D"
            }).Entity;


            ctx.MOTD.AddRange(motd1);
            ctx.MOTD.AddRange(motd);
            ctx.SpecialOffers.AddRange(spcl);
            ctx.Ingredients.AddRange(ingr);
            ctx.Ingredients.AddRange(ingr1);
            ctx.MainFood.AddRange(mainFood);
            ctx.MainFood.AddRange(mainFood1);
            ctx.User.AddRange(users);
            ctx.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
