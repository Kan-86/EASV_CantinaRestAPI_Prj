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
   public class UnitTestMainFood
    {
    
        Mock<IMainFoodRepositories> mainFoodRepo;
        Mock<IAllergensRepositories> allergensRepo;
        Mock<IIngredientsRepositories> IngredientsRepo;
        IMainFoodServices mainFoodService;

        public UnitTestMainFood()
        {
            mainFoodRepo = new Mock<IMainFoodRepositories>();
            allergensRepo = new Mock<IAllergensRepositories>();
            IngredientsRepo = new Mock<IIngredientsRepositories>();
            mainFoodService = new MainFoodServices(mainFoodRepo.Object,
                IngredientsRepo.Object,

                allergensRepo.Object
                );

        }
        [TestMethod]
        public void createMainfoodWithoutName()
        {
            var menu = new MainFood()
            {
               
            };
            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
               mainFoodService.AddMainFood(menu));
            Assert.AreEqual("Main Food needs a name.", ex.Message);

        }
        [TestMethod]
        public void deleteWithoutIdLowerThan1()
        {
            var menu = new MainFood()
            {
                Id=0
            };
            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
               mainFoodService.DeleteMainFood(menu.Id));
            Assert.AreEqual("ID requires to be greater than 0.", ex.Message);

        }
        [TestMethod]
        public void FindByIdWithoutId()
        {
            var menu = new MainFood()
            {
                Id = 0
            };
            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
               mainFoodService.FindMainFoodIdIncludeRecipAlrg(menu.Id));
            Assert.AreEqual("ID requires to be greater than 0.", ex.Message);

        }
        [TestMethod]
        public void UpdateMainFoodWithIdLowerThan1()
        {
            var menu = new MainFood()
            {
                Id = 0,
                MainFoodName = "pasta"
            };
            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
               mainFoodService.UpdateMainFood(menu));
            Assert.AreEqual("You need to have an higher id than 0", ex.Message);

        }

        public void UpdateMainFoodWithoutName()
        {
            var menu = new MainFood()
            {
                Id = 1
            };
            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
               mainFoodService.FindMainFoodIdIncludeRecipAlrg(menu.Id));
            Assert.AreEqual("Main Food needs a name.", ex.Message);

        }


    }
}
