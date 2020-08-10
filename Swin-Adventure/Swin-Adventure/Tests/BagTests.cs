using NUnit.Framework;
using System;
using Swin_Adventure;


namespace Tests
{
    [TestFixture()]
    public class BagTests
    {
        Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
        Item shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");

        [Test()]
        public void LocatesItems()
        {
            Bag bag = new Bag(new string[] {"hahalol"}, "lol", "this yeah woah yeah");
            bag.Inventory.Put(sword);

            Assert.AreEqual(bag.Locate(sword.FirstId()), sword);
            Assert.IsTrue(bag.Inventory.HasItem(sword.FirstId()));
        }

        [Test()]
        public void LocatesItself()
        {
            Bag bag = new Bag(new string[] { "hahalol" }, "lol", "this yeah woah yeah");

            Assert.AreEqual(bag.Locate("hahalol"), bag);
        }

        [Test()]
        public void LocatesNothing()
        {
            Bag bag = new Bag(new string[] { "hahalol" }, "lol", "this yeah woah yeah");

            Assert.AreEqual(bag.Locate("sadfasdfsdafasdf"), null);
        }

        [Test()]
        public void FullDescription()
        {
            Bag bag = new Bag(new string[] { "hahalol" }, "lol", "this yeah woah yeah");

            bag.Inventory.Put(sword);
            bag.Inventory.Put(shovel);

            Assert.AreEqual(bag.FullDescription,
                $"In the {bag.Name} you can see:\n\ta {sword.FirstId()} ({sword.Name})" +
                "\n\t" +
                $"a {shovel.FirstId()} ({shovel.Name})");
        }

        [Test()]
        public void BagInBag()
        {
            Bag bag1 = new Bag(new string[] { "bag1" }, "bag1", "red bag");
            Bag bag2 = new Bag(new string[] { "bag2" }, "bag2", "blue bag");

            //put shovel in bag 2
            bag2.Inventory.Put(shovel);

            bag1.Inventory.Put(bag2);


            //Bag 1 can locate bag 2
            Assert.AreEqual(bag1.Locate("bag2"), bag2);


            //Bag1 can locate other items in bag 1
            bag1.Inventory.Put(sword);
            Assert.AreEqual(bag1.Locate(sword.FirstId()), sword);

            //bag1 can not locate items in bag2
            Assert.AreEqual(bag1.Locate(shovel.FirstId()), null);


        }

    }
}
