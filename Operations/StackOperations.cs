using MyGenerics.Models;
using System;

namespace MyGenerics.Operations
{
    internal class StackOperations
    {
        public static void Start()
        {
            MyStack<string> mine = new MyStack<string>();
            Console.WriteLine("A Stack has been initialized");
            Console.WriteLine();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Enter 1 : to Push an item to the stack");
                Console.WriteLine("Enter 2 : to Pop from the Stack");
                Console.WriteLine("Enter 3 : to peek first item in the Stack");
                Console.WriteLine("Enter 4 : to show size of the Stack");
                Console.WriteLine("Enter 5 : to print all items in the Stack");
                Console.WriteLine("Enter 6 : to check if the Stack is empty");
                Console.WriteLine("Enter 7 : to Exit the Stack");
                Console.WriteLine();

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Enter the value you want to Push");
                        string value = Console.ReadLine();
                        mine.Push(value);
                        Console.WriteLine($"{value} was added into the Stack");
                        Console.WriteLine();
                        break;

                    case "2":
                        if (mine.Count > 0)
                            Console.WriteLine($"{mine.Pop()} was removed from the Stack");
                        else
                            Console.WriteLine("Nothing left to pop");
                        Console.WriteLine();
                        break;

                    case "3":
                        if (mine.Count > 0)
                            Console.WriteLine($"The first value in the Stack is {mine.Peek()}");
                        else
                            Console.WriteLine("The Stack is empty");
                        Console.WriteLine();
                        break;

                    case "4":
                        Console.WriteLine($"The Stack has {mine.Count} items");
                        Console.WriteLine();
                        break;

                    case "5":
                        mine.Print();
                        Console.WriteLine();
                        break;

                    case "6":
                        string @empty = "The Stack is empty";
                        string @hasValue = "The Stack is not empty";
                        Console.WriteLine($"{(mine.IsEmpty() ? @empty : @hasValue)}");
                        Console.WriteLine();
                        break;

                    case "7":
                        running = false;
                        break;
                }
            }
        }
    }
}