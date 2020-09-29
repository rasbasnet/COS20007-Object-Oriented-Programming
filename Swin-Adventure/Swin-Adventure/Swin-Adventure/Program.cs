using System;

namespace Swin_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Swin Adventure\n");
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("Describe yourself: ");
            string description = Console.ReadLine();

            Player me = new Player(name, description);
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade :|");
            Location lake = new Location(new string[] { "location", "lake" }, "Lake", "Frozen blue lake spans across the Sivon Lands");
            Item shovel = new Item(new string[] { "shovel" }, "bronze shovel", "this is a.... shovel");

            lake.Inventory.Put(sword);
            me.Inventory.Put(shovel);
            me.Location = lake;

            Bag bag = new Bag(new string[] { "bag", "BAGGGG" }, "Bag", "this yeah woah yeah is a bag");
            Item gun = new Item(new string[] { "gun" }, "big gun", "this is a.... gun boom boom");

            me.Inventory.Put(bag);
            bag.Inventory.Put(gun);

            Look_Command look = new Look_Command();

            string command;
            bool ongoing = true;
            while (ongoing)
            {
                Console.Write("Command: ");
                command = Console.ReadLine();
                if (command.ToLower() != "end")
                {
                    Console.WriteLine(look.Execute(me, command.Split()));
                } else
                {
                    Console.WriteLine("Exiting...");
                    ongoing = false;
                }
            }
        }
    }
}
