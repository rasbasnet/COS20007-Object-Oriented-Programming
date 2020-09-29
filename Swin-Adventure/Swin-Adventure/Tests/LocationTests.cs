using NUnit.Framework;
using System;
using Swin_Adventure;

namespace Tests
{
    [TestFixture()]
    public class LocationTests
    {
        private Location _lake;
        private Item _sword;
        private Player _me;

        [SetUp()]
        public void Init()
        {
            _lake = new Location(new string[] { "location", "_lake" }, "_lake", "Frozen blue _lake spans across the Sivon Lands");
            _sword = new Item(new string[] { "_sword" }, "_sword", "black blade");
            _me = new Player("_me", "yes");
        }
        [TestCase()]
        public void LocationIdentifyItself()
        {
            Assert.AreEqual(_lake.Locate("_lake"), _lake);
            Assert.AreEqual(_lake.Locate("location"), _lake);
        }
        [TestCase()]
        public void LocationCanLocateItems()
        {
            _lake.Inventory.Put(_sword);
            Assert.AreEqual(_lake.Locate("_sword"), _sword);
        }
        [TestCase()]
        public void PlayerCanLocateItemsInTheirLocation()
        {
            _lake.Inventory.Put(_sword); //put _sword in _lake
            _me.Location = _lake; // location of player in _lake
            Assert.AreEqual(_me.Locate("_sword"), _sword);
        }
        [TestCase()]
        public void PlayersCanLocateTheirLocation()
        {
            _me.Location = _lake;
            Assert.AreEqual(_me.Locate("_lake"), _lake);
        }
    }
}
