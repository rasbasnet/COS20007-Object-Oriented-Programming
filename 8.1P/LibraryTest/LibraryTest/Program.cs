using System;

namespace LibraryTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Library library = new Library("St Saint Station Library");
            Book book1 = new Book("The Count of Monte Cristo", "Alexandre Dumas", "XX987");
            Book book2 = new Book("Norwegian Wood", "Haruki Murakami", "XX789");
            Game game1 = new Game("Leauge of Legends", "Riot Games", "9/10");
            Game game2 = new Game("GTA V", "Rockstar", "10/10");

            library.AddResource(book1);
            library.AddResource(book2);
            library.AddResource(game1);
            library.AddResource(game2);

            book1.OnLoan = true; 
            game1.OnLoan = true; 

            Console.WriteLine(library.HasResource("Norwegian Wood")); // Not on Loan
            Console.WriteLine(library.HasResource("Leauge of Legends")); // On Loan



        }
    }
}
