using CantinaApp.Core.Entity.Entities;
using CantinaApp.Core.Entity.Models;
using EASV_CantinaRestAPI.Helpers;
using System;
using System.Collections.Generic;

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

            string password = "4321";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<Users> users = new List<Users>
            {
                new Users {
                    Username = "kris",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = true
                },
                new Users {
                    Username = "jacob",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = false
                }
            };
            var user1 = ctx.Users.Add(new Users()
            {
                Username = "Username 1"

            }).Entity;

            var user2 = ctx.Users.Add(new Users()
            {
                Username = "username 2"
            }).Entity;

            var ingr = ctx.Ingredients.Add(new Ingredients()
            {
                IngredientName = "KasperBBQ Sauce",

            }).Entity;

            var mainFood = ctx.MainFood.Add(new MainFood()
            {
                MainFoodName = "Sams special Kasper Sauce",
                FoodDate = DateTime.Today
            }).Entity;


            var mainFood1 = ctx.MainFood.Add(new MainFood()
            {

                MainFoodName = "PineAppleCoffeeSandwitch",
                FoodDate = new DateTime(2017,12,12)
            }).Entity;



            var ingr1 = ctx.Ingredients.Add(new Ingredients()
            {
                IngredientName = "Kasper and Kris Sauce",

            }).Entity;

            var spcl = ctx.SpecialOffers.Add(new SpecialOffers()
            {
                SpecialOfferName = "Swedish Meatballs",
                OffersDate = DateTime.Today
            }).Entity;

            var motd = ctx.MOTD.Add(new MOTD()
            {
                TipOfTheDay = "One Icelander per day, makes problems go away"
            }).Entity;

            var motd1 = ctx.MOTD.Add(new MOTD()
            {
                TipOfTheDay = "Why do Swedish go out when they hear a thunderstorm? Because they think they are being photographed :D"
            }).Entity;


            ctx.MOTD.AddRange(motd1);
            ctx.MOTD.AddRange(motd);
            ctx.SpecialOffers.AddRange(spcl);
            ctx.Ingredients.AddRange(ingr);
            ctx.Ingredients.AddRange(ingr1);
            ctx.MainFood.AddRange(mainFood);
            ctx.MainFood.AddRange(mainFood1);
            ctx.Users.AddRange(users);
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
