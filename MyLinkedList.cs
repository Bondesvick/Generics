using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MyGenerics.Base;

namespace MyGenerics
{
    /// <summary>
    /// A class that replicates the functionality of a LinkedList
    /// </summary>
    /// <typeparam name="T">The Generic type</typeparam>
    internal class MyLinkedList<T> : IEnumerable<T>
    {
        private readonly MyCollectionBase<T> _theLinkedList;

        public MyCollectionNode<T> First => _theLinkedList.First;
        public int Count => _theLinkedList.Count;
        public MyCollectionNode<T> Last => _theLinkedList.Last;

        public MyLinkedList()
        {
            _theLinkedList = new MyCollectionBase<T>();
        }

        public MyLinkedList(int capacity)
        {
            _theLinkedList = new MyCollectionBase<T>(capacity);
        }

        public void AddFirst(T value)
        {
            _theLinkedList.AddFirst(value);
        }

        public void AddFirst(MyLinkedListNode<T> value)
        {
            _theLinkedList.AddFirst(value);
        }

        public void AddLast(T value)
        {
            _theLinkedList.AddLast(value);
        }

        public void AddLast(MyLinkedListNode<T> value)
        {
            _theLinkedList.AddLast(value);
        }

        /// <summary>
        /// Adds a node before another node
        /// </summary>
        /// <param name="before">The node whose position is to be replaced</param>
        /// <param name="value">The node to replace an existing node's position</param>
        public void AddBefore(MyLinkedListNode<T> before, MyLinkedListNode<T> value)
        {
            _theLinkedList.AddBefore(before, value);
        }

        public void AddBefore(MyLinkedListNode<T> before, T value)
        {
            _theLinkedList.AddBefore(before, value);
        }

        public void AddAfter(MyLinkedListNode<T> after, MyLinkedListNode<T> value)
        {
            _theLinkedList.AddAfter(after, value);
        }

        public void AddAfter(MyLinkedListNode<T> after, T value)
        {
            _theLinkedList.AddAfter(after, value);
        }

        public MyLinkedListNode<T> Find(T value)
        {
            return (MyLinkedListNode<T>)_theLinkedList.Find(value);
        }

        public MyLinkedListNode<T> FindLast(T value)
        {
            return (MyLinkedListNode<T>)_theLinkedList.FindLast(value);
        }

        public void Remove(MyLinkedListNode<T> value)
        {
            _theLinkedList.Remove(value);
        }

        public bool? Remove(T value)
        {
            return _theLinkedList.Remove(value);
        }

        public void RemoveFirst()
        {
            _theLinkedList.RemoveFirst();
        }

        public void RemoveLast()
        {
            _theLinkedList.RemoveLast();
        }

        public int? IndexOf(T value) => _theLinkedList.IndexOf(value);

        public bool Contains(T value) => _theLinkedList.Contains(value);

        public IEnumerator<T> GetEnumerator()
        {
            return _theLinkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}