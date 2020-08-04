using System;
using System.Collections.Generic;
using System.Text;
using MyGenerics.Base;

namespace MyGenerics
{
    internal class MyLinkedListNode<T> : MyCollectionNode<T>
    {
        private MyLinkedList<T> List { get; }

        public MyLinkedListNode(T value) : base(value)
        {
        }
    }
}