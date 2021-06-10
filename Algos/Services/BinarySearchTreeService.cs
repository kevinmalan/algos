using Algos.Data_Structures;
using System;
using System.Collections.Generic;

namespace Algos.Services
{
    public class BinarySearchTreeService
    {
        public Node GetSeededTree()
        {
            var root = new Node(1, new Node(2, left: new Node(4), right: new Node(5)),
                                                    new Node(3, left: new Node(6), right: new Node(7, left: new Node(8), right: null)));

            return root;
        }

        /// <summary>
        /// Breadth: The distance from side to side.
        /// BFS: Algorithm for traversing / searching a tree / graph.
        /// Starts at the root and explores all of the neighbour nodes at the present depth prior to moving on to the next depth level.
        /// Opposite strategy of Depth First Search (DFS)
        /// </summary>
        public void TraverseTreeBreadthFirstSearch(Node node)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                Console.Write($"{node.Value} "); // Prints 1, 2, 3, 4, 5, 6, 7, 8

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        /// <summary>
        /// Depth: The distance from the top to the bottom.
        /// DFS: Algorithm for traversing / searching a tree / graph.
        /// Starts at the root and explores the node branch as far as possible before being forced to backtrack and expand other nodes.
        /// </summary>
        public void TraverseTreeDepthFirstSearch(Node node)
        {
            if (node is null) return;

            Console.Write($"{node.Value} "); // Prints 1, 2, 4, 5, 3, 6 7, 8
            TraverseTreeDepthFirstSearch(node.Left);
            TraverseTreeDepthFirstSearch(node.Right);
        }
    }
}