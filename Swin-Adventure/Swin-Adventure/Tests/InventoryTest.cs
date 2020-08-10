using NUnit.Framework;
using System;
using Swin_Adventure;
namespace Tests
{
    [TestFixture()]
    public class InventoryTest
    {
        [Test()]
        public void FindItem()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] {"sword"}, "sword", "black blade");
            inventory.Put(sword);

            Assert.IsTrue(inventory.HasItem(sword.FirstId()));
        }
        [Test()]
        public void NoItemFind()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            inventory.Put(sword);

            Assert.IsFalse(inventory.HasItem("gun"));
        }
        [Test()]
        public void FetchItem()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            inventory.Put(sword);
            inventory.Fetch(sword.FirstId());

            Assert.AreEqual(inventory.Fetch(sword.FirstId()), sword);
            Assert.IsTrue(inventory.HasItem(sword.FirstId()));
        }

        [Test()]
        public void TakeItem()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            inventory.Put(sword);

            Assert.AreEqual(inventory.Take(sword.FirstId()), sword);

            inventory.Take(sword.FirstId());
            Assert.IsFalse(inventory.HasItem(sword.FirstId()));
        }

        [Test()]
        public void ItemList()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Item shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");

            inventory.Put(sword);
            inventory.Put(shovel);

            Assert.AreEqual(inventory.Items,
                $"\n\ta {sword.FirstId()} ({sword.Name})" +
                "\n\t" +
                $"a {shovel.FirstId()} ({shovel.Name})");
        }
    }
}