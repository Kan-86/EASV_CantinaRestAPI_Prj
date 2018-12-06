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
    public  class UnitSpecielOffers
    {
        /*
         * Create speciel offers
         * */
        Mock<ISpecialOffersRepositories> SpecielOffersRepo;
        ISpecialOffersServices SpecielOffersService;
        public UnitSpecielOffers()
        {
            SpecielOffersRepo = new Mock<ISpecialOffersRepositories>();
            SpecielOffersService = new SpecialOffersServices(SpecielOffersRepo.Object);
        }

        [TestMethod]
        public void CreateSpecialOfferWithPrice0()
        {
            var spec = new SpecialOffers()
            {
                Price = 0,
                SpecialOfferName = "banan"

            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.AddSpecialOffer(spec));
            Assert.AreEqual("Price need to be higher than 0", ex.Message);
        }

        [TestMethod]
        public void CreateSpecialOfferWithPriceNull()
        {
            var spec = new SpecialOffers()
            {
                
                SpecialOfferName = "banan"

            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.AddSpecialOffer(spec));
            Assert.AreEqual("Price need to be higher than 0", ex.Message);
        }

        [TestMethod]
        public void CreateSpecialOfferWithNoName()
        {
            var spec = new SpecialOffers()
            {

                Price = 100

            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.AddSpecialOffer(spec));
            Assert.AreEqual("Speciel offer need a name", ex.Message);
        }

        /*
         * Delete speciel offers
         * */
        [TestMethod]
        public void DeleteSpecialOfferWithNoId()
        {
            var id = 0;

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.DeleteSpecialOffer(id));
            Assert.AreEqual("Id need to be higher than 0", ex.Message);
        }

        /*
         * Get by id speciel offers
         * */
        [TestMethod]
        public void GetByIdSpecialOfferWithNoId()
        {
            var id = 0;

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.GetSpecialOffersById(id));
            Assert.AreEqual("Id need to be higher than 0", ex.Message);
        }

        /*
        * update by id speciel offers
        * */
        [TestMethod]
        public void UpdateSpecielOfferPrice0()
        {
            var spec = new SpecialOffers()
            {
                Id = 1,
                Price = 0,
                SpecialOfferName = "banan"

            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.UpdateSpecialOffer(spec));
            Assert.AreEqual("Price need to be higher than 0", ex.Message);
        }

        [TestMethod]
        public void UpdateSpecialOfferWithPriceNull()
        {
            var spec = new SpecialOffers()
            {
                Id = 1,
                SpecialOfferName = "banan"

            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.UpdateSpecialOffer(spec));
            Assert.AreEqual("Price need to be higher than 0", ex.Message);
        }

        [TestMethod]
        public void UpdateSpecialOfferWithNoName()
        {
            var spec = new SpecialOffers()
            {
                Id=1,
                Price = 100

            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.UpdateSpecialOffer(spec));
            Assert.AreEqual("Speciel offer need a name", ex.Message);
        }

        public void UpdateByIdSpecialOfferWithNoId()
        {
            var spec = new SpecialOffers()
            {
                SpecialOfferName="Banan",
                Price = 100

            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                SpecielOffersService.UpdateSpecialOffer(spec));
            Assert.AreEqual("Id need to be higher than 0", ex.Message);
        }
    }
}
