using System;
using System.Collections.Generic;
using System.Text;

namespace MyGenerics.Base
{
    internal class MyCollectionNode<T>
    {
        public MyCollectionNode<T> Previous { get; set; }
        public MyCollectionNode<T> Next { get; set; }
        public T Value { get; set; }

        public MyCollectionNode(T value)
        {
            Value = value;
        }
    }
}