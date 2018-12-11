using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.ApplicationServices.Services;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTestMOTD
    {
        Mock<IMOTDRepositories> MotdRepo;
        IMOTDServices motdService;
        public UnitTestMOTD()
        {
             MotdRepo = new Mock<IMOTDRepositories>();
            motdService = new MOTDServices(MotdRepo.Object);
        }

        [TestMethod]
        public void CreateMOTDWithoutMessage()
        {
            var motd = new MOTD()
            {

            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                motdService.AddMOTD(motd));
            Assert.AreEqual("You need to write a message", ex.Message);
        }

        [TestMethod]
        public void CreateMOTDWithName()
        {
            var motd = new MOTD()
            {
                TipOfTheDay= "One Dane per day, makes problems go away"
            };

            motdService.AddMOTD(motd);
        }

        [TestMethod]
        public void DeleteWithIdOf0()
        {
            int id = 0;
            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                motdService.DeleteMOTD(id));
            Assert.AreEqual("ID requires to be greater than 0.", ex.Message);
        }

        [TestMethod]
        public void DeleteWithokayId()
        {
            int id = 1;
            motdService.DeleteMOTD(id);
        }

        [TestMethod]
        public void ReadWithIdOf0()
        {
            int id = 0;
            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                motdService.GetMOTDById(id));
            Assert.AreEqual("ID requires to be greater than 0.", ex.Message);
        }

        [TestMethod]
        public void ReadWithIdOf1()
        {
            int id = 1;
            motdService.DeleteMOTD(id);
        }

        [TestMethod]
        public void UpdateWithId0()
        {
            var motd = new MOTD()
            {
                Id = 0,
                TipOfTheDay = "One Dane per day, makes problems go away"
            };

            Exception ex = Assert.ThrowsException<ArgumentException>(() =>
                motdService.UpdateMOTD(motd));
            Assert.AreEqual("You need to have an higher id than 0", ex.Message);
        }

    }
}
