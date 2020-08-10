using System;

namespace Swin_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player me = new Player("me", "yes");
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Item shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");

            me.Inventory.Put(sword);
            me.Inventory.Put(shovel);


            Console.WriteLine(me.Locate("sword").FirstId());
            Console.WriteLine("Inventory Items\n" + me.FullDescription);

        }
    }
}
