using System;
namespace Swin_Adventure
{
    public class Bag : Item, I_Have_Inventory
    {
        private Inventory _inventory;
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {

            _inventory = new Inventory();

        }

        public override string FullDescription
        {
            get
            {
                string des = $"In the {this.Name} you can see:";
                des += _inventory.Items;
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

        public Inventory Inventory { get => _inventory; }
    }
}
