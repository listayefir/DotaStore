using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotaStore.Domain.Entities;

namespace DotaStore.UnitTests
{
    [TestClass]
    public class CartTests
    {
        private Item i1;
        private Item i2;

        private void SetItems()
        {
            i1 = new Item()
            {
                Cathegory = "Badge",
                Description = null,
                ID = new Guid(new byte[] {2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9}),
                Name = "A",
                Picture = null,
                Price = 15.00m,
                ProductionDate = null
            };

            i2 = new Item()
            {
                Cathegory = "Badge",
                Description = null,
                ID = new Guid(new byte[] { 2, 3, 6, 5, 6, 7, 8, 2, 2, 3, 4, 7, 6, 7, 8, 9 }),
                Name = "B",
                Picture = null,
                Price = 15.00m,
                ProductionDate = null
            };

        }
        [TestMethod]
        public void AddItemTest()
        {
            SetItems();
            Cart cart = new Cart();

            cart.AddItem(i1, 1);
            cart.AddItem(i2, 2);

            var result = cart.GetOrder().OrderBy(i=>i.Item.Name).ToArray();

            Assert.AreEqual(2,result.Length);
            Assert.AreEqual("A", result[0].Item.Name);
            Assert.AreEqual("B", result[1].Item.Name);
            Assert.AreEqual(2, result[1].Quantity);
        }

        [TestMethod]
        public void AddQuantityToExistingItemTest()
        {
            SetItems();
            Cart cart = new Cart();

            cart.AddItem(i1, 1);
            cart.AddItem(i2, 2);
            cart.AddItem(i1,2);

            var result = cart.GetOrder().OrderBy(i => i.Item.Name).ToArray();

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(3, result[0].Quantity);
        }

        [TestMethod]
        public void RemoveItemTest()
        {
            SetItems();
            Cart cart = new Cart();
            cart.AddItem(i1, 1);
            cart.AddItem(i2, 2);
            cart.AddItem(i1, 2);
            cart.RemoveLine(i1);

            var result = cart.GetOrder().OrderBy(i => i.Item.Name);

            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(condition: result.All(l => l.Item != i1));

        }

        [TestMethod]
        public void TotalPriceTest()
        {
            SetItems();
            var cart = new Cart();
            cart.AddItem(i1,2);
            cart.AddItem(i2,3);

            Assert.AreEqual(75, cart.TotalPrice());
        }

        [TestMethod]
        public void ClearCartTest()
        {
            SetItems();
            var cart = new Cart();

            cart.AddItem(i1, 2);
            cart.AddItem(i2, 3);

            cart.Clear();

            Assert.IsTrue(!cart.GetOrder().Any());
        }

    }
}
