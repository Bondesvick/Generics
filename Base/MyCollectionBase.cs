using System;
using System.Collections;
using System.Collections.Generic;

namespace MyGenerics.Base
{
    internal class MyCollectionBase<T> : ICollection<T>
    {
        /// <summary>
        /// The first item
        /// </summary>
        public MyCollectionNode<T> First
        {
            get;
            private set;
        }

        /// <summary>
        /// The last item
        /// </summary>
        public MyCollectionNode<T> Last
        {
            get;
            private set;
        }

        /// <summary>
        /// Lisy capacity
        /// </summary>
        private int _capacity = 4;

        /// <summary>
        /// The constructor
        /// </summary>
        public MyCollectionBase()
        {
        }

        /// <summary>
        /// The constructor overload with a capacity parameter
        /// </summary>
        /// <param name="capacity"></param>
        public MyCollectionBase(int capacity)
        {
            _capacity = capacity;
        }

        /// <summary>
        /// Adds an item to the top of the list
        /// </summary>
        /// <param name="value">the item to add</param>
        public void AddFirst(T value)
        {
            AddFirst(new MyCollectionNode<T>(value));
        }

        /// <summary>
        /// An overload that adds a node to the top of the list
        /// </summary>
        /// <param name="node">the node to add</param>
        public void AddFirst(MyCollectionNode<T> node)
        {
            MyCollectionNode<T> temp = First;

            First = node;
            First.Next = temp;

            if (Count == 0)
            {
                Last = First;
            }
            else
            {
                temp.Previous = First;
            }

            Count++;
            if (Count == _capacity)
            {
                _capacity *= 2;
            }
        }

        /// <summary>
        /// Adds item to the end of the list
        /// </summary>
        /// <param name="value">the item to add</param>
        public void AddLast(T value)
        {
            AddLast(new MyCollectionNode<T>(value));
        }

        /// <summary>
        /// An overload that adds a node to the end of the list
        /// </summary>
        /// <param name="node">the node to add</param>
        public void AddLast(MyCollectionNode<T> node)
        {
            if (Count == 0)
            {
                First = node;
            }
            else
            {
                Last.Next = node;

                node.Previous = Last;
            }

            Last = node;
            Count++;
            if (Count == _capacity)
            {
                _capacity *= 2;
            }
        }

        /// <summary>
        /// removes the first node on the list
        /// </summary>
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                First = First.Next;

                Count--;

                if (Count == 0)
                {
                    Last = null;
                }
                else
                {
                    First.Previous = null;
                }
            }
        }

        /// <summary>
        /// Removes the last node on the list
        /// </summary>
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    First = null;
                    Last = null;
                }
                else
                {
                    Last.Previous.Next = null;
                    Last = Last.Previous;
                }

                Count--;
            }
        }

        /// <summary>
        /// Adds a node before another node in the list
        /// </summary>
        /// <param name="before">The node whose position is to be replaced</param>
        /// <param name="value">The node to be added</param>
        public void AddBefore(MyCollectionNode<T> before, MyCollectionNode<T> value)
        {
            if (Exist(before))
            {
                MyCollectionNode<T> previous = before.Previous;
                if (previous != null)
                {
                    previous.Next = value;
                    value.Previous = previous;
                }
                else
                {
                    value.Previous = null;
                }
                value.Next = before;
                before.Previous = value;

                Count--;
                if (Count == _capacity)
                {
                    _capacity *= 2;
                }
            }
            else
            {
                Console.WriteLine("Node not found");
            }
        }

        /// <summary>
        /// Adds an item before another node in the list
        /// </summary>
        /// <param name="before">The node whose position is to be replaced</param>
        /// <param name="value">The item whose node is to be added</param>
        public void AddBefore(MyCollectionNode<T> before, T value)
        {
            AddBefore(before, new MyCollectionNode<T>(value));
        }

        /// <summary>
        /// Adds a node after another node
        /// </summary>
        /// <param name="after">The node that comes before the node to be added</param>
        /// <param name="value">The node to be added</param>
        public void AddAfter(MyCollectionNode<T> after, MyCollectionNode<T> value)
        {
            if (Exist(after))
            {
                MyCollectionNode<T> next = after.Next;
                if (next != null)
                {
                    value.Next = next;
                    next.Previous = value;
                }
                else
                {
                    value.Next = null;
                }

                value.Previous = after;
                after.Next = value;

                Count++;
                if (Count == _capacity)
                {
                    _capacity *= 2;
                }
            }
            else
            {
                Console.WriteLine("Node not found");
            }
        }

        /// <summary>
        /// Adds an item after another node
        /// </summary>
        /// <param name="after">The node that comes before the node to be added</param>
        /// <param name="value">The item whose node is to be added</param>
        public void AddAfter(MyCollectionNode<T> after, T value)
        {
            AddAfter(after, new MyCollectionNode<T>(value));
        }

        /// <summary>
        /// The size of the list
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds an item at the top of the list
        /// </summary>
        /// <param name="item">The value to add</param>
        public void Add(T item)
        {
            AddFirst(item);
        }

        /// <summary>
        /// Find and returns the first node that contains the value in the list
        /// </summary>
        /// <param name="item">the item to search</param>
        /// <returns>The returned node</returns>
        public MyCollectionNode<T> Find(T item)
        {
            MyCollectionNode<T> current = First;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Inserts a value at a particular index in the list
        /// </summary>
        /// <param name="value">The value to insert</param>
        /// <param name="index">The index you intend the value to</param>
        /// <returns></returns>
        public bool Insert(T value, int index)
        {
            if (Count != 0)
            {
                MyCollectionNode<T> found = FindNode(index);
                if (found != null)
                {
                    AddBefore(found, value);
                    return true;
                }
                else
                {
                    Console.WriteLine("index not found");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("index not found");
                return false;
            }
        }

        /// <summary>
        /// Searches for a node at a particular given index
        /// </summary>
        /// <param name="index">the given index</param>
        /// <returns>The returned node</returns>
        public MyCollectionNode<T> FindNode(int index)
        {
            int aCount = 0;
            MyCollectionNode<T> current = First;
            while (current != null)
            {
                if (aCount == index)
                {
                    return current;
                }

                aCount++;
                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Find and returns the Last node that contains the value in the list
        /// </summary>
        /// <param name="item">the item to search</param>
        /// <returns>The returned node</returns>
        public MyCollectionNode<T> FindLast(T item)
        {
            MyCollectionNode<T> current = Last;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }

                current = current.Previous;
            }

            return null;
        }

        /// <summary>
        /// Check and returns true if the given node exists in the list
        /// </summary>
        /// <param name="node">The node to check</param>
        /// <returns>The returned boolean value</returns>
        public bool Exist(MyCollectionNode<T> node)
        {
            MyCollectionNode<T> current = First;
            while (current != null)
            {
                if (current == node)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Checks and returns true if a value is present in the list
        /// </summary>
        /// <param name="item">The passed value</param>
        /// <returns>The returned boolean value</returns>
        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        /// <summary>
        /// Copies the items in the list into another array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            MyCollectionNode<T> current = First;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Checks if the list is reead only
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an item from the list and returns true if successful
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>The returned boolean value</returns>
        public bool Remove(T item)
        {
            MyCollectionNode<T> found = Find(item);
            if (found == null)
            {
                return false;
            }

            MyCollectionNode<T> previous = found.Previous;
            MyCollectionNode<T> next = found.Next;

            if (previous == null)
            {
                First = next;
                if (First != null)
                {
                    First.Previous = null;
                }
            }
            else
            {
                previous.Next = next;
            }

            if (next == null)
            {
                Last = previous;
                if (Last != null)
                {
                    Last.Next = null;
                }
            }
            else
            {
                next.Previous = previous;
            }

            Count--;

            return true;
        }

        /// <summary>
        /// Removes an item from the list and returns true if successful
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>The returned boolean value</returns>
        public bool Remove(MyCollectionNode<T> value)
        {
            if (Exist(value))
            {
                MyCollectionNode<T> found = value;
                if (found == null)
                {
                    return false;
                }

                MyCollectionNode<T> previous = found.Previous;
                MyCollectionNode<T> next = found.Next;

                if (previous == null)
                {
                    First = next;
                    if (First != null)
                    {
                        First.Previous = null;
                    }
                }
                else
                {
                    previous.Next = next;
                }

                if (next == null)
                {
                    Last = previous;
                    if (Last != null)
                    {
                        Last.Next = null;
                    }
                }
                else
                {
                    next.Previous = previous;
                }

                Count--;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Wipes out all item in the list
        /// </summary>
        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        /// <summary>
        /// sets the capacity of the list to the real size of the list
        /// </summary>
        public void TrimExcess()
        {
            this._capacity = Count;
        }

        /// <summary>
        /// returns the index of a value in the List
        /// </summary>
        /// <param name="value">The value whose index you want to return</param>
        /// <returns>the returned index</returns>
        public int? IndexOf(T value)
        {
            int index = 0;
            MyCollectionNode<T> current = First;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }

                index++;
                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Checks and returns true if list is empty
        /// </summary>
        /// <returns>the returned boolean value</returns>
        public bool IsEmpty() => (Count < 1) ? true : false;

        /// <summary>
        /// Searches for an item in the list and returns
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object Search(T value)
        {
            if (Contains(value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Enables iteration on the list
        /// </summary>
        /// <returns>The return Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            MyCollectionNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Enables iteration on the list
        /// </summary>
        /// <returns>The return Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}