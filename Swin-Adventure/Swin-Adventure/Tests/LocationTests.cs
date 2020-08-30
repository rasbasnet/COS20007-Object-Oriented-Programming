using NUnit.Framework;
using System;
using Swin_Adventure;


namespace Tests
{
    [TestFixture()]
    public class LocationTests
    {


        [Test()]
        public void LocationIdentifyItself()
        {
            Location lake = new Location(new string[] {"location", "lake"}, "Lake", "Frozen blue lake spans across the Sivon Lands");
            Assert.AreEqual(lake.Locate("lake"), lake);
            Assert.AreEqual(lake.Locate("location"), lake);

        }

        [Test()]
        public void LocationCanLocateItems()
        {
            Location lake = new Location(new string[] {"location", "lake"}, "Lake", "Frozen blue lake spans across the Sivon Lands");
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");

            lake.Inventory.Put(sword);

            Assert.AreEqual(lake.Locate("sword"), sword);

        }

        [Test()]
        public void PlayerCanLocateItemsInTheirLocation()
        {
            Location lake = new Location(new string[] { "location", "lake" }, "Lake", "Frozen blue lake spans across the Sivon Lands");
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Player me = new Player("me", "yes");

            lake.Inventory.Put(sword); //put sword in lake

            me.Location = lake; // location of player in lake


            Assert.AreEqual(me.Locate("sword"), sword);

        }


        [Test()]
        public void PlayersCanLocateTheirLocation()
        {
            Location lake = new Location(new string[] { "location", "lake" }, "Lake", "Frozen blue lake spans across the Sivon Lands");
            Player me = new Player("me", "yes");


            me.Location = lake;


            Assert.AreEqual(me.Locate("lake"), lake);

        }
    }


}
