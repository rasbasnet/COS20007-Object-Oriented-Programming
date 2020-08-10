using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello World - from Message Object");
            myMessage.Print();

            Message[] messages = new Message[4];
            messages[0] = new Message("Welcome back oh great educator!");
            messages[1] = new Message("What a lovely name!");
            messages[2] = new Message("Great Name!");
            messages[3] = new Message("That is a silly name");

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            if (name.ToLower() == "chris")
            {
                messages[0].Print();
            } else if (name.ToLower() == "fred")
            {
                messages[1].Print();
            } else if (name.ToLower() == "wilma")
            {
                messages[2].Print();
            } else
            {
                messages[3].Print();
            }

        }
    }
}
