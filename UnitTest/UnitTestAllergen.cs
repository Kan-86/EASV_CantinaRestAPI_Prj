using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.ApplicationServices.Services;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class UnitTestAllergen
    {
        Mock<IAllergensRepositories> AllergensRepo;
        IAllergenServices AllergensService;
        public UnitTestAllergen()
        {
            AllergensRepo = new Mock<IAllergensRepositories>();
            AllergensService = new AllergenServices(AllergensRepo.Object);
        }

       /* [TestMethod]
        public void createAllergenWithoutNew()
        {
            var allergen = new Allergen()
            {
                FoodIconType = new FoodIcon()
                {
                    FoodIconType = "hey"
                },
                


            };

        }*/
    }
}
