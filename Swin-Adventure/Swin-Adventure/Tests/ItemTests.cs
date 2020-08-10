using NUnit.Framework;
using System;
using Swin_Adventure;

namespace Tests
{
    [TestFixture()]
    public class ItemTests
    {
        [Test()]
        public void Identifiable()
        {
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Assert.IsTrue(sword.AreYou("sword"));
        }

        [Test()]
        public void ShortDescription()
        {
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Assert.AreEqual(sword.ShortDescription, $"a {sword.FirstId()} ({sword.Name})");
        }


        [Test()]
        public void LongDescription()
        {
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Assert.AreEqual(sword.FullDescription, "black blade");
        }
    }
}
