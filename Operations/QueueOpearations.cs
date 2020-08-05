using MyGenerics.Models;
using System;

namespace MyGenerics.Operations
{
    internal class QueueOperations
    {
        public static void Start()
        {
            MyQueue<string> mine = new MyQueue<string>();
            Console.WriteLine("A Queue has been initialized");
            Console.WriteLine();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Enter 1 : to Enqueue an item");
                Console.WriteLine("Enter 2 : to Dequeue from the Queue");
                Console.WriteLine("Enter 3 : to show size of the Queue");
                Console.WriteLine("Enter 4 : to print all items in the Queue");
                Console.WriteLine("Enter 5 : to check if Queue is empty");
                Console.WriteLine("Enter 6 : to Exit the Queue");
                Console.WriteLine();

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Enter the value you want to Enqueue");
                        string value = Console.ReadLine();
                        mine.Enqueue(value);
                        Console.WriteLine($"{value} was added into the Queue");
                        Console.WriteLine();
                        break;

                    case "2":
                        if (mine.Count > 0)
                            Console.WriteLine($"{mine.Dequeue()} was removed from the Queue");
                        else
                            Console.WriteLine("Nothing left to dequeue");
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine($"The Queue has {mine.Count} items");
                        Console.WriteLine();
                        break;

                    case "4":
                        mine.Print();
                        Console.WriteLine();
                        break;

                    case "5":
                        string @empty = "The Queue is empty";
                        string @hasValue = "The Queue is not empty";
                        Console.WriteLine($"{(mine.IsEmpty() ? @empty : @hasValue)}");
                        Console.WriteLine();
                        break;

                    case "6":
                        running = false;
                        break;
                }
            }
        }
    }
}