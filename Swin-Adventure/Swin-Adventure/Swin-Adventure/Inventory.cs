using System;
using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Inventory
    {
        private List<Item> _items;



        public Inventory()
        {
            _items = new List<Item>();

        }



        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.FirstId() == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item item)
        {

            _items.Add(item);

        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;

        }

        public Item Take(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }

        public string Items
        {
            get
            {
                string l = "";
                foreach (Item item in _items)
                {
                    l = l + "\n\t" + item.ShortDescription;
                }
                return l;
            }
        }
    }
}
