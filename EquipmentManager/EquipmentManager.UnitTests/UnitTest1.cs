using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void AddItemTest()
        {
            // Arrange
            var target = new FakeItemRepository();


            Item item = new Item { ItemID = 8 };
            // Act
            target.AddItem(item);

            // Assert
            Assert.AreSame(item, target.GetItem(8));
        }

        [TestMethod]

        public void GetItemTest()
        {

            // Arrange

            var target = new FakeItemRepository();

            Item item1 = new Item { ItemID = 1, Name = "Ipod Touch", Description = "1st Generation", Category = "Mp3 Player", Operational = true, CheckedOut = false };
            Item item2 = new Item { ItemID = 2, Name = "Ipod Nano", Description = "2nd Generation", Category = "Mp3 Player", Operational = true, CheckedOut = false };
            Item item3 = new Item { ItemID = 3, Name = "Ipod Shuffle", Description = "3rd Generation", Category = "Mp3 Player", Operational = true, CheckedOut = false };

            target.AddItem(item1);
            target.AddItem(item2);
            target.AddItem(item3);

            // Act

            Item retrievedItem = target.GetItem(2);

            // Assert

            Assert.AreSame(retrievedItem, item2);

        }
    }
}
