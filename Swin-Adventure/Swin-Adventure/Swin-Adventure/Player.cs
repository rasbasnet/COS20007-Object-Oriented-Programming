using System;
namespace Swin_Adventure
{
    public class Player : GameObject, I_Have_Inventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] {"me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string FullDescription
        {
            get
            {
                string des = "You are carrying:";
                des +=_inventory.Items;
                return des;
            }
        }
        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }

            if (_inventory.Fetch(id) != null)
            {
                return _inventory.Fetch(id);
            }

            return _location == null ? null : _location.Locate(id);

        }

        public Inventory Inventory { get => _inventory;}
        public Location Location { get => _location; set => _location = value; }
    }
}
