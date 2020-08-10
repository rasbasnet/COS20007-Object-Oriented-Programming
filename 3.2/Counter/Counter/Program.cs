using System;

namespace Counter
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Clock timeKeeper = new Clock();
            for (int i = 0; i < 60*60*24 + 3; i++)
            {
                Console.WriteLine(timeKeeper.ReadTime);
                timeKeeper.Tick();
            }
        }
    }
}
