using NUnit.Framework;
using System;
using Swin_Adventure;

namespace Tests
{
    [TestFixture()]
    public class PlayerTests
    {
        [Test()]
        public void Identifiable()
        {
            Player me = new Player("me", "yes");
            Assert.IsTrue(me.AreYou("me"));
            Assert.IsTrue(me.AreYou("inventory"));
        }

        [Test()]
        public void LocateItems()
        {
            Player me = new Player("me", "yes");
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            me.Inventory.Put(sword);
            Assert.AreEqual(me.Locate(sword.FirstId()), sword);
        }

        [Test()]
        public void LocateThemselves()
        {
            Player me = new Player("me", "yes");
            Assert.AreEqual(me.Locate("me"), me);
            Assert.AreEqual(me.Locate("inventory"), me);
        }

        [Test()]
        public void LocateNothing()
        {
            Player me = new Player("me", "yes");
            Assert.AreEqual(me.Locate("hahahahahhaha"), null);
        }

        [Test()]
        public void FullDescription()
        {
            Player me = new Player("me", "yes");
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Item shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");

            me.Inventory.Put(sword);
            me.Inventory.Put(shovel);

            Assert.AreEqual(me.FullDescription,
                $"You are carrying:\n\ta {sword.FirstId()} ({sword.Name})" +
                "\n\t" +
                $"a {shovel.FirstId()} ({shovel.Name})");
        }
    }

}
