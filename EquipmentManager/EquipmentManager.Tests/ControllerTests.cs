using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EquipmentManager.Domain.Entities;
using EquipmentManager.WebUI.Controllers;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.WebUI.Models;
using EquipmentManager.WebUI.HtmlHelpers;
using Moq;
using Ninject;
using System.Linq;
using System.Web.Mvc;

namespace EquipmentManager.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void ShowItemTest()
        {
            // Arrange

            // - Create the mock repository
            var repo = new FakeItemRepository();

            Item item3 = new Item { ItemID = 1, Name = "Ipod Nano", Category = "Mp3 Player", Description = "2nd Generation", CheckedOut = false, Operational = false };
            Item item4 = new Item { ItemID = 2, Name = "Ipod Shuffle", Category = "Mp3 Player", Description = "1st Generation", CheckedOut = false, Operational = false };
            Item item5 = new Item { ItemID = 3, Name = "Ipod Touch", Category = "Mp3 Player", Description = "3rd Generation", CheckedOut = false, Operational = false };

            // Arrange - Create the Controller

            var target = new ItemController(repo);

            // Act

            repo.AddItem(item3);
            repo.AddItem(item4);
            repo.AddItem(item5);
            Item testItem = (Item)target.ShowItem(item3).Model;

            // Assert

            Assert.AreSame(item3, testItem);
        }

        //[TestMethod]
        //public void GetTicketTest()
        //{
        //    // Arrange

        //    // - Create the mock repository
        //    var repo = new FakeItemRepository();

        //    Item item3 = new Item { ItemID = 1, Name = "Ipod Nano", Category = "Mp3 Player", Description = "2nd Generation", CheckedOut = false, Operational = false };
        //    Item item4 = new Item { ItemID = 2, Name = "Ipod Shuffle", Category = "Mp3 Player", Description = "1st Generation", CheckedOut = true, Operational = false };
        //    Item item5 = new Item { ItemID = 3, Name = "Ipod Touch", Category = "Mp3 Player", Description = "3rd Generation", CheckedOut = true, Operational = false };

        //    // Arrange - Create the Controller

        //    var target = new ItemController(repo);

        //    // Act

        //    repo.AddItem(item3);
        //    repo.AddItem(item4);
        //    repo.AddItem(item5);



        //    // Assert




    }
}
