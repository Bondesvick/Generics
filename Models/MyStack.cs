using MyGenerics.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyGenerics.Models
{
    /// <summary>
    /// A class that replicates all the features Generic Stack
    /// </summary>
    /// <typeparam name="T">the generic type passed</typeparam>
    internal class MyStack<T> : IEnumerable
    {
        /// <summary>
        /// Instantiating My collection base class
        /// </summary>
        private readonly MyCollectionBase<T> _theStackList;

        /// <summary>
        /// Returns the Number of items in the stack
        /// </summary>
        public int Count => _theStackList.Count;

        /// <summary>
        /// A constructor that initializes the stack with a capacity
        /// </summary>
        /// <param name="capacity"></param>
        public MyStack(int capacity)
        {
            _theStackList = new MyCollectionBase<T>(capacity);
        }

        /// <summary>
        /// A constructor that initializes the Stack
        /// </summary>
        public MyStack()
        {
            _theStackList = new MyCollectionBase<T>();
        }

        /// <summary>
        /// Adds an item to the top of the Stack
        /// </summary>
        /// <param name="value">the item to add</param>
        public void Push(T value)
        {
            _theStackList.AddFirst(value);
        }

        /// <summary>
        /// Removes the item at top of the stack and returns it
        /// </summary>
        /// <returns>The item removed</returns>
        public T Pop()
        {
            T toReturn = _theStackList.First.Value;
            _theStackList.RemoveFirst();

            return toReturn;
        }

        /// <summary>
        /// Tries to remove the item at the top of the Stack
        /// </summary>
        /// <param name="result">The removed item if successful</param>
        /// <returns>Boolean confirmation of whether the item was removed</returns>
        public bool TryPop(out T result)
        {
            if (_theStackList.Count > 0)
            {
                result = _theStackList.First.Value;
                _theStackList.RemoveFirst();
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Looks and returns the item at the top of the stack
        /// </summary>
        /// <returns>Item at the top of the stack</returns>
        public T Peek() => _theStackList.First.Value;

        /// <summary>
        /// Tries to return the item at the top of the stack
        /// </summary>
        /// <param name="result">The returned item if successful</param>
        /// <returns>A boolean confirmation of whether the operation was successful</returns>
        public bool TryPeek(out T result)
        {
            if (_theStackList.Count > 0)
            {
                result = _theStackList.First.Value;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Clears out all the items in the stack
        /// </summary>
        public void Clear()
        {
            _theStackList.Clear();
        }

        /// <summary>
        /// Copies the items in the Stack to an array of same generic type
        /// </summary>
        /// <param name="array">destination array</param>
        /// <param name="index">starting index</param>
        public void CopyTo(T[] array, int index)
        {
            _theStackList.CopyTo(array, index);
            //foreach (var item in _theStackList)
            //{
            //    array.SetValue(item, index);
            //    index += 1;
            //}
        }

        /// <summary>
        /// Returns an array representation of the stack
        /// </summary>
        /// <returns>The returned array</returns>
        public T[] ToArray() => _theStackList.ToArray();

        public void TrimExcess()
        {
            _theStackList.TrimExcess();
        }

        /// <summary>
        /// Checks if the Queue is empty and returns true, otherwise false
        /// </summary>
        /// <returns>The returned boolean value</returns>
        public bool IsEmpty() => _theStackList.Count < 1;

        /// <summary>
        /// returns the size of the queue
        /// </summary>
        /// <returns>The returned size</returns>
        public int Size() => _theStackList.Count;

        /// <summary>
        /// Prints all the values in the Stack
        /// </summary>
        public void Print()
        {
            foreach (var item in _theStackList)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// returns the Enumerator of the Stack
        /// </summary>
        /// <returns>The Stack returned as an Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _theStackList)
            {
                yield return item;
            }
            //return _theStackList.GetEnumerator();
        }

        /// <summary>
        /// Implemented from the IEnumerable Interface which allows the Stack to iterated/Enumerated
        /// </summary>
        /// <returns>The IEnumerable of the Stack</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}