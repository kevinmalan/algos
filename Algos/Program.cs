using Algos.Services;
using System;

namespace Algos
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hi! Select an option below to continue:");
            Console.WriteLine("=========================");
            Console.WriteLine($"bst: Binary Search Tree");
            Console.WriteLine($"ht: Hash Tables");
            Console.WriteLine($"hts: Hash Tables Space Complexity");
            Console.WriteLine($"ahc: Array Hourglass");
            Console.WriteLine($"q: Quit");

            var input = Console.ReadLine();

            while (input != "q")
            {
                switch (input)
                {
                    case "bst":
                        OperateBinarySearchTrees();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case "ht":
                        OperateHashTables();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case "hts":
                        HashMapSpaceComplexity();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case "ahc":
                        ArrayHourglass();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case "q":
                        input = "q";
                        break;

                    default:
                        Console.WriteLine("That ain't an option (yet) sadly");
                        break;
                }

                if (input != "q")
                {
                    Console.WriteLine($"Choose another option:");
                    input = Console.ReadLine();
                }
            }

            Console.WriteLine($"Thank you, see ya later!");
        }

        public static void ArrayHourglass()
        {
            var data = new int[][]
            {
                new int[] { 1, 1, 1, 0, 0, 0, },
                new int[] { 0, 1, 0, 0, 0, 0, },
                new int[] { 1, 1, 1, 0, 0, 0, },
                new int[] { 0, 0, 2, 4, 4, 0, },
                new int[] { 0, 0, 0, 2, 0, 0, },
                new int[] { 0, 0, 1, 2, 4, 0, },
            };

            var arrayService = new ArrayService();
            var result = arrayService.GetHighestHourglassSum(data);

            Console.WriteLine($"Highest Hourglass sum: {result}");
        }

        public static void HashMapSpaceComplexity()
        {
            var hashTableService = new HashTableService();
            hashTableService.AssessSpaceComplxityOfCustomHashMapVsBuiltIn();
        }

        public static void OperateBinarySearchTrees()
        {
            Console.WriteLine("Binary Search Trees:");
            Console.WriteLine();
            var bst = new BinarySearchTreeService();
            var nodeSeed = bst.GetSeededTree();

            Console.WriteLine($"Structure:");

            Console.Write($"Level 1: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Level 2: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2 & 3");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Level 3: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4 & 5, 6 & 7");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Level 4: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("8");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Traversing Breadth First:");
            Console.ForegroundColor = ConsoleColor.Green;
            bst.TraverseTreeBreadthFirstSearch(nodeSeed);
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Traversing Depth First:");
            Console.ForegroundColor = ConsoleColor.Green;
            bst.TraverseTreeDepthFirstSearch(nodeSeed);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void OperateHashTables()
        {
            Console.WriteLine("Hash Tables:");
            Console.WriteLine();
            var hashTableService = new HashTableService();

            var userRolesMaps = hashTableService.GetUserRolesMap();
            Console.WriteLine("CEO: " + userRolesMaps.GetValue("CEO"));
            Console.WriteLine("Replacing value of key CEO...");
            var userRoles = hashTableService.ReplaceUserRole("CEO", "Evil Morty");
            Console.WriteLine("CEO: " + userRoles.GetValue("CEO"));

            Console.WriteLine("Current CTO: " + userRolesMaps.GetValue("CTO"));
            Console.WriteLine("Adding additional value to key CTO...");
            userRoles = hashTableService.AddAdditionalUserToRole("CTO", "Mr. Robot");
            Console.WriteLine("CTOs: " + userRoles.GetValue("CTO"));

            var stokItemsMap = hashTableService.GetItemsStockMap();
            Console.WriteLine("Burger Count: " + stokItemsMap.GetValue("Burger"));
            Console.WriteLine("Pizza Count: " + stokItemsMap.GetValue("Pizza"));

            Console.WriteLine("Increasing Burger stock by 11...");
            var stockItems = hashTableService.IncreaseStockQuantity("Burger", 11);
            Console.WriteLine("Burger Count: " + stockItems.GetValue("Burger"));

            Console.WriteLine("Increasing Pizza stock by 15...");
            stockItems = hashTableService.IncreaseStockQuantity("Pizza", 15);
            Console.WriteLine("Pizza Count: " + stockItems.GetValue("Pizza"));
        }
    }
}