using NUnit.Framework;
using System;
using Swin_Adventure;


namespace Tests
{
    [TestFixture()]
    public class LookCommandTests
    {

        Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
        Item shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");
        Item gem = new Item(new string[] { "gem" }, "shiny gem", "this is a gem :| ");


        [Test()]
        public void TestLookAtMe()
        {
            Player me = new Player("me", "yes");
            Look_Command look = new Look_Command();

            Assert.AreEqual(look.Execute(me, new string[] {"look", "at", "inventory"}), me.FullDescription);

        }


        [Test()]
        public void TestLookAtGem()
        {
            Player me = new Player("me", "yes");
            me.Inventory.Put(gem);
            Look_Command look = new Look_Command();

            Assert.AreEqual(look.Execute(me, new string[] { "look", "at", "gem" }), gem.FullDescription);
        }


        [Test()]
        public void TestLookAtUnk()
        {
            Player me = new Player("me", "yes");
            Look_Command look = new Look_Command();

            Assert.AreEqual(look.Execute(me, new string[] { "look", "at", "gem" }), "I can't find the gem");
        }

        [Test()]
        public void TestLookAtGemInMe()
        {
            Player me = new Player("me", "yes");
            me.Inventory.Put(gem);
            Look_Command look = new Look_Command();

            Assert.AreEqual(look.Execute(me, new string[] { "look", "at", "gem", "in", "inventory" }), gem.FullDescription);
        }

        [Test()]
        public void TestLookAtGemInBag()
        {
            Player me = new Player("me", "yes");
            Bag bag = new Bag(new string[] { "bag" }, "bag bag bag", "this yeah woah yeah is a bag");

            bag.Inventory.Put(gem);
            me.Inventory.Put(bag);
            Look_Command look = new Look_Command();

            Assert.AreEqual(look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }), gem.FullDescription);
        }

        [Test()]
        public void TestLookAtGemInNoBag()
        {
            Player me = new Player("me", "yes");
            me.Inventory.Put(gem);
            Look_Command look = new Look_Command();

            Assert.AreEqual(look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }), "I can't find the bag");
        }

        [Test()]
        public void TestLookAtNoGemInBag()
        {
            Player me = new Player("me", "yes");
            Bag bag = new Bag(new string[] { "bag" }, "bag bag bag", "this yeah woah yeah is a bag");

            me.Inventory.Put(bag);
            Look_Command look = new Look_Command();

            Assert.AreEqual(look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }), "I can't find the gem");
        }

        [Test()]
        public void TestInvalidLook()
        {
            Player me = new Player("me", "yes");
            Look_Command look = new Look_Command();

            Assert.AreEqual(look.Execute(me, new string[] { "stare", "at", "gem"}), "Error in look input.");
        }
    }
}
