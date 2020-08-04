using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyGenerics.Base;

//using System.Linq;

//using System.Collections.Generic;

namespace MyGenerics
{
    internal class Program
    {
        private static void Main(string[] args)

        {
            LinkedList<int> wer = new LinkedList<int>();
            LinkedListNode<int> iu = new LinkedListNode<int>(6);

            MyLinkedList<int> mine = new MyLinkedList<int>();

            mine.AddLast(5);
            mine.AddLast(6);
            mine.AddLast(7);
            mine.AddLast(8);
            mine.AddLast(9);

            mine.AddFirst(10);

            mine.Remove(8);
            mine.AddLast(10);
            mine.RemoveLast();
            mine.RemoveFirst();

            foreach (var item in mine)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(mine.IndexOf(10));
        }
    }
}