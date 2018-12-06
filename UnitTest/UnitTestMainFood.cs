using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.ApplicationServices.Services;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestMainFood
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
                allergensRepo.Object);
        }

        [TestMethod]
        public void CreateMainFoodWithoutName()
        {
            var mainFood = new MainFood()
            {
                FoodIconType = new FoodIcon()
                {
                    FoodIconType = "hey"
                },
                IngredientsType = new List<Ingredients>() {
                    new Ingredients()
                    {
                         FoodIconType = new FoodIcon()
                             {
                                 FoodIconType = "hey"
                                },
                        IngredientType= "hey",


                    }

                },
            };

            Exception ex = Assert.ThrowsException<InvalidOperationException>(() =>
                mainFoodService.AddMainFood(mainFood));
            Assert.AreEqual("Main Food needs a name.", ex.Message);
        }

        [TestMethod]
        public void CreateMainFoodWithoutIngrediens()
        {
            var mainFood = new MainFood()
            {
                FoodIconType = new FoodIcon()
                {
                    FoodIconType = "hey"
                },
                MainFoodName = "hey"
            };

            Exception ex = Assert.ThrowsException<InvalidOperationException>(() =>
                mainFoodService.AddMainFood(mainFood));
            Assert.AreEqual("Main food need some ingredients", ex.Message);
        }

        [TestMethod]
        public void CreateMainFoodWithoutIcon()
        {
            var mainFood = new MainFood()
            {
                IngredientsType = new List<Ingredients>() {
                    new Ingredients()
                    {
                         FoodIconType = new FoodIcon()
                             {
                                 FoodIconType = "hey"
                                },
                        IngredientType= "hey",


                    }

                },
                MainFoodName = "hey"
            };

            Exception ex = Assert.ThrowsException<InvalidOperationException>(() =>
                mainFoodService.AddMainFood(mainFood));
            Assert.AreEqual("Main food needs an icon", ex.Message);
        }

        [TestMethod]
        public void DeleteMain()
        {
            var id = 0;

            Exception ex = Assert.ThrowsException<InvalidOperationException>(() =>
                mainFoodService.DeleteMainFood(id));
            Assert.AreEqual("Main Food Id needs to be larger than 1.", ex.Message);
        }

        [TestMethod]
        public void ReadById0()
        {
            var id = 0;

            Exception ex = Assert.ThrowsException<InvalidOperationException>(() =>
                mainFoodService.FindMainFoodId(id));
            Assert.AreEqual("Main Food Id needs to be larger than 1.", ex.Message);
        }

    }
}
