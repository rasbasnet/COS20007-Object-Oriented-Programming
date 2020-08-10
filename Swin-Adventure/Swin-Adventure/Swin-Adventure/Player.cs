using System;
namespace Swin_Adventure
{
    public class Player : GameObject
    {
        private Inventory _inventory;
        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
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
            return _inventory.Fetch(id);
        }

        public Inventory Inventory { get => _inventory;}
    }
}
