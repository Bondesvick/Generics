using MyGenerics.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyGenerics.Models
{
    internal class MyQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Instantiating My collection base class
        /// </summary>
        private readonly MyCollectionBase<T> _theQueueList;

        /// <summary>
        /// initializes MyQueue class with a capacity
        /// </summary>
        /// <param name="capacity">The capacity of the Queue</param>
        public MyQueue(int capacity)
        {
            _theQueueList = new MyCollectionBase<T>(capacity);
        }

        /// <summary>
        /// A constructor overload that initializes the MyQueue class
        /// </summary>
        public MyQueue()
        {
            _theQueueList = new MyCollectionBase<T>();
        }

        /// <summary>
        /// Adds an item to the end of the Queue
        /// </summary>
        /// <param name="value">the value to be added</param>
        public void Enqueue(T value)
        {
            _theQueueList.AddLast(value);
        }

        /// <summary>
        /// Removes the first item on the queue and returns it
        /// </summary>
        /// <returns>the removed item</returns>
        public T Dequeue()
        {
            var first = _theQueueList.First.Value;
            _theQueueList.RemoveFirst();
            return first;
        }

        /// <summary>
        /// Tries to remove the first item in the queue and returns true if successful
        /// </summary>
        /// <param name="result">the dequeued item</param>
        /// <returns>true if successful and false if unsuccessful</returns>
        public bool TryDequeue(out T result)
        {
            if (_theQueueList.Count > 0)
            {
                result = _theQueueList.First.Value;
                _theQueueList.RemoveFirst();
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Wipes away all the values in the queue
        /// </summary>
        public void Clear()
        {
            this._theQueueList.Clear();
        }

        /// <summary>
        /// Returns the number of items in the Queue
        /// </summary>
        public int Count => _theQueueList.Count;

        /// <summary>
        /// Checks if an item is present in the queue and returns true or false
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>the boolean confirmation returned</returns>
        public bool Contains(T value) => _theQueueList.Contains(value);

        /// <summary>
        /// Returns the Queue as an array of its generic type
        /// </summary>
        /// <returns></returns>
        public T[] ToArray() => _theQueueList.ToArray();

        /// <summary>
        /// Returns the first item in the Queue
        /// </summary>
        /// <returns>The first item on the queue</returns>
        public T Peek() => _theQueueList.First.Value;

        /// <summary>
        /// Tries to return the first item in the Queue
        /// </summary>
        /// <param name="result">First item return if it exists</param>
        /// <returns>Boolean confirmation stating whether operation was successful</returns>
        public bool TryPeek(out T result)
        {
            if (_theQueueList.Count > 0)
            {
                result = _theQueueList.First.Value;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Copies the items in the Queue to an array of same generic type
        /// </summary>
        /// <param name="array">destination array</param>
        /// <param name="index">starting index</param>
        public void CopyTo(T[] array, int index)
        {
            foreach (var item in _theQueueList)
            {
                array.SetValue(item, index);
                index += 1;
            }
        }

        /// <summary>
        /// Sets the capacity of the Queue to the actual size of the queue
        /// </summary>
        public void TrimExcess()
        {
            _theQueueList.TrimExcess();
        }

        /// <summary>
        /// Checks if the Queue is empty and returns true, otherwise false
        /// </summary>
        /// <returns>The returned boolean value</returns>
        public bool IsEmpty() => _theQueueList.Count < 1;

        /// <summary>
        /// Prints all the values in the queue
        /// </summary>
        public void Print()
        {
            foreach (var item in _theQueueList)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// returns the Enumerator of the Queue
        /// </summary>
        /// <returns>The Queue returned as an Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _theQueueList.GetEnumerator();
        }

        /// <summary>
        /// Implemented from the IEnumerable Interface which allows the Queue to iterated/Enumerated
        /// </summary>
        /// <returns>The IEnumerable of the Queue</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}