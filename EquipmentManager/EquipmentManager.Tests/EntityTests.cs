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
    public class EntityTests
    {

        [TestMethod]

        public void CanLookupItem()
        {

            // Arrange

            var target2 = new FakeItemRepository();

            Item item3 = new Item { ItemID = 1, Name = "Ipod Nano", Category = "Mp3 Player", Description = "2nd Generation", CheckedOut = false, Operational = false };
            Item item4 = new Item { ItemID = 2, Name = "Ipod Shuffle", Category = "Mp3 Player", Description = "1st Generation", CheckedOut = false, Operational = false };
            Item item5 = new Item { ItemID = 3, Name = "Ipod Touch", Category = "Mp3 Player", Description = "3rd Generation", CheckedOut = false, Operational = false };


            target2.AddItem(item3);
            target2.AddItem(item4);
            target2.AddItem(item5);

            // Act

            Item retrievedItem = target2.GetItem(2);

            // Assert

            Assert.AreEqual(retrievedItem.ItemID, item4.ItemID);
        }

        [TestMethod]

        public void CanDeleteItem()
        {

            // Arrange

            var target2 = new FakeItemRepository();

            Item item3 = new Item { ItemID = 1, Name = "Ipod Nano", Category = "Mp3 Player", Description = "2nd Generation", CheckedOut = false, Operational = false };
            Item item4 = new Item { ItemID = 2, Name = "Ipod Shuffle", Category = "Mp3 Player", Description = "1st Generation", CheckedOut = false, Operational = false };
            Item item5 = new Item { ItemID = 3, Name = "Ipod Touch", Category = "Mp3 Player", Description = "3rd Generation", CheckedOut = false, Operational = false };


            target2.AddItem(item3);
            target2.AddItem(item4);
            target2.AddItem(item5);

            // Act

            target2.DeleteItem(item3.ItemID);
            target2.DeleteItem(item4.ItemID);

            // Assert

            Assert.AreEqual(target2.FakeItems.Count(), 1);
        }

        [TestMethod]

        public void CanAddToTicket()
        {

            Item item3 = new Item { ItemID = 1, Name = "Ipod Nano", Category = "Mp3 Player", Description = "2nd Generation", CheckedOut = false, Operational = false };
            Item item4 = new Item { ItemID = 2, Name = "Ipod Shuffle", Category = "Mp3 Player", Description = "1st Generation", CheckedOut = false, Operational = false };
            Item item5 = new Item { ItemID = 3, Name = "Ipod Touch", Category = "Mp3 Player", Description = "3rd Generation", CheckedOut = false, Operational = false };


            Ticket ticket = new Ticket();

            ticket.AddItem(item3);

            Assert.AreEqual(ticket.Lines.Count(), 1);
        }
    }
}
