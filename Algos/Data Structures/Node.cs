using System;
using System.Collections.Generic;
using System.Text;

namespace Algos.Data_Structures
{
    /// <summary>
    /// Tree
    /// </summary>
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public Node(int value, Node left, Node right)
        {
            Left = left;
            Right = right;
            Value = value;
        }
    }
}