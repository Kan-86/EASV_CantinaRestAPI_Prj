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
            //allergensRepo = new Mock<IAllergensRepositories>();
            IngredientsRepo = new Mock<IIngredientsRepositories>();
            mainFoodService = new MainFoodServices(mainFoodRepo.Object,
                IngredientsRepo.Object
                );
        }
       /*   Check this   */
        [TestMethod]
        public void CreateMainFoodWithoutName()
        {
            /*
            var mainFood = new MainFood()
            {
                FoodIconId = 1,
                RecipeLines = new List<RecipeLine>
                {
                    new RecipeLine()
                    {
                        IngredientsId=1,
                        IngredientsType = new Ingredients()
                        {
                            Id=1
                        },
                        MainFoodId=2,
                        MainFoodType = new MainFood()
                        {
                            Id=2
                        }
                    }

                },
                AllergensTypeId = null,
                Id=1,
                MainFoodName="pizza"
              
            };

            Exception ex = Assert.ThrowsException<InvalidOperationException>(() =>
            mainFoodService.AddMainFood(mainFood));
            Assert.AreEqual("Your Main Food Id's need to be the same", ex.Message);*/
            }
        
           
        

        [TestMethod]
        public void CreateMainFoodWithoutIngrediens()
        {
          
        }

        [TestMethod]
        public void CreateMainFoodWithoutIcon()
        {
           
        }

        [TestMethod]
        public void DeleteMain()
        {
           
        }

        [TestMethod]
        public void ReadById0()
        {
          
        }

    }
}
