using MyGenerics.Operations;
using System;

//using System.Linq;

//using System.Collections.Generic;

namespace MyGenerics
{
    internal class Program
    {
        private static void Main(string[] args)

        {
            Console.WriteLine("=================================================================================================");
            Console.WriteLine("                                             WELCOME");
            Console.WriteLine("=================================================================================================");
            Console.WriteLine();

            bool running = true;

            while (running)
            {
                Console.WriteLine("ENTER 1 : TO INITIALIZE A QUEUE");
                Console.WriteLine("ENTER 2 : TO INITIALIZE A STACK");
                Console.WriteLine("ENTER 3 : TO INITIALIZE A LINKED-LIST");
                Console.WriteLine("ENTER 4 : TO EXIT");
                Console.WriteLine();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        QueueOperations.Start();
                        break;

                    case "2":
                        StackOperations.Start();
                        break;

                    case "3":
                        LinkedListOperations.Start();
                        break;

                    case "4":
                        Console.WriteLine("Good bye!");
                        running = false;
                        break;
                }
            }
        }
    }
}