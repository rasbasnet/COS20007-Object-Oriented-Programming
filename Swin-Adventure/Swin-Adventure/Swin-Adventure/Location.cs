using System;
namespace Swin_Adventure
{
    public class Location : GameObject, I_Have_Inventory
    {
        private Inventory _inventory;
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        public Inventory Inventory { get => _inventory; }
    }
}
