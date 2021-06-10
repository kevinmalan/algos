using Algos.Services;
using System;

namespace Algos
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var bst = new BinarySearchTreeService();
            var nodeSeed = bst.GetSeededTree();

            bst.TraverseTreeBreadthFirstSearch(nodeSeed);
            Console.WriteLine();
            bst.TraverseTreeDepthFirstSearch(nodeSeed);
        }
    }
}