using MyGenerics.Models;
using System;

namespace MyGenerics.Operations
{
    internal class LinkedListOperations
    {
        public static void Start()
        {
            MyLinkedList<string> mine = new MyLinkedList<string>();
            Console.WriteLine("A LinkedList has been initialized");
            Console.WriteLine();
            bool running = true;
            //mine.
            while (running)
            {
                Console.WriteLine("Enter 1 : to Add an item to the LinkedList");
                Console.WriteLine("Enter 2 : to Remove from the Stack");
                Console.WriteLine("Enter 3 : to Check if an item is present in the LinkedList");
                Console.WriteLine("Enter 4 : to insert a value at an index in the List");
                Console.WriteLine("Enter 5 : to show the size of the LinkedList");
                Console.WriteLine("Enter 6 : to check if the List is empty");
                Console.WriteLine("Enter 7 : to check the index of a value");
                Console.WriteLine("Enter 8 : to search for an item in the LinkedList");
                Console.WriteLine("Enter 9 : to Exit the LinkedList");
                Console.WriteLine();

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Enter the value you want to add");
                        string value = Console.ReadLine();
                        mine.AddLast(value);
                        Console.WriteLine($"{value} was added into the LinkedList");
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine("Enter the value you want to remove");
                        string item = Console.ReadLine();
                        if (mine.Remove(item))
                            Console.WriteLine($"{item} was removed from the Stack");
                        else
                            Console.WriteLine("the value you entered is not in the list ");
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine("Enter the value you want to check");
                        string check = Console.ReadLine();
                        if (mine.Contains(check))
                            Console.WriteLine($"The value is on the LinkedList");
                        else
                            Console.WriteLine("The value is not on the LinkedList");
                        Console.WriteLine();
                        break;

                    case "4":
                        Console.WriteLine("Enter the value you want to insert");
                        string toInsert = Console.ReadLine();
                        Console.WriteLine("Enter the index you want to insert the value to");
                        int toIndex = int.Parse(Console.ReadLine() ?? string.Empty);
                        if (mine.Insert(toInsert, toIndex))
                            Console.WriteLine($"{toInsert} was inserted at index {toIndex}");
                        else
                            Console.WriteLine($"{toInsert} was not inserted");
                        Console.WriteLine();
                        break;

                    case "5":
                        Console.WriteLine($"The size of the LinkedList is {mine.Count}");
                        Console.WriteLine();
                        break;

                    case "6":
                        string @empty = "The List is empty";
                        string @hasValue = "The List is not empty";
                        Console.WriteLine($"{(mine.IsEmpty() ? @empty : @hasValue)}");
                        Console.WriteLine();
                        break;

                    case "7":
                        Console.WriteLine("Enter the value you want to Check its index");
                        string toCheck = Console.ReadLine();
                        if (mine.IndexOf(toCheck) != null)
                            Console.WriteLine($"The index of {toCheck} is {mine.IndexOf(toCheck)}");
                        else
                            Console.WriteLine("The value you entered is not in the list");
                        Console.WriteLine();
                        break;

                    case "8":
                        Console.WriteLine("Enter the item you want to search");
                        string anItem = Console.ReadLine();
                        if (mine.Search(anItem) != null)
                            Console.WriteLine($"{anItem} was found in the List");
                        else
                            Console.WriteLine($"{anItem} was not found");
                        Console.WriteLine();
                        break;

                    case "9":
                        running = false;
                        break;
                }
            }
        }
    }
}