using Algos.Data_Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algos.Services
{
    public class HashTableService
    {
        public HashTableString GetUserRolesMap()
        {
            var userRoles = new HashTableString();
            userRoles.AddOrReplace("CEO", "Gavin Belson");
            userRoles.AddOrReplace("CTO", "Rick Sanchez");
            userRoles.AddOrReplace("CFO", "Vitalik Buterin");

            return userRoles;
        }

        public HashTableString ReplaceUserRole(string role, string newUser)
        {
            var userRoles = GetUserRolesMap();
            userRoles.AddOrReplace(role, newUser);

            return userRoles;
        }

        public HashTableString AddAdditionalUserToRole(string role, string newUser)
        {
            var userRoles = GetUserRolesMap();
            userRoles.AddOrIncrement(role, newUser);

            return userRoles;
        }

        public HashTableInt GetItemsStockMap()
        {
            var items = new HashTableInt();
            items.AddOrReplace("Burger", 199);
            items.AddOrReplace("Pizza", 185);

            return items;
        }

        public HashTableInt IncreaseStockQuantity(string item, int additionalQuantity)
        {
            var stock = GetItemsStockMap();
            stock.AddOrIncrement(item, additionalQuantity);

            return stock;
        }

        public void AssessSpaceComplxityOfCustomHashMapVsBuiltIn()
        {
            var custom = GetItemsStockMap();
            var builtIn = new Dictionary<string, int>();

            // 1
            var timeToSeedCustom1 = SeedCustom(custom, 1);
            var timeToSeedBuiltIn1 = SeedBuiltIn(builtIn, 1);
            var timeToGetValueCustom1 = GetValueCustom(custom, "100");
            var timeToGetValueBuiltIn1 = GetValueBuiltIn(builtIn, "100");

            // 2
            var timeToSeedCustom2 = SeedCustom(custom, 101);
            var timeToSeedBuiltIn2 = SeedBuiltIn(builtIn, 101);
            var timeToGetValueCustom2 = GetValueCustom(custom, "200");
            var timeToGetValueBuiltIn2 = GetValueBuiltIn(builtIn, "200");

            // 3
            var timeToSeedCustom3 = SeedCustom(custom, 201);
            var timeToSeedBuiltIn3 = SeedBuiltIn(builtIn, 201);
            var timeToGetValueCustom3 = GetValueCustom(custom, "300");
            var timeToGetValueBuiltIn3 = GetValueBuiltIn(builtIn, "300");

            Console.WriteLine($"Custom Seed 1: {timeToSeedCustom1}");
            Console.WriteLine($"Custom Seed 1: {timeToSeedCustom2}");
            Console.WriteLine($"Custom Seed 3: {timeToSeedCustom3}");

            Console.WriteLine($"BuiltIn Seed 1: {timeToSeedBuiltIn1}");
            Console.WriteLine($"BuiltIn Seed 2: {timeToSeedBuiltIn2}");
            Console.WriteLine($"BuiltIn Seed 3: {timeToSeedBuiltIn3}");

            Console.WriteLine($"Custom GetValue 1: {timeToGetValueCustom1}");
            Console.WriteLine($"Custom GetValue 2: {timeToGetValueCustom2}");
            Console.WriteLine($"Custom GetValue 3: {timeToGetValueCustom3}");

            Console.WriteLine($"BuiltIn GetValue 1: {timeToGetValueBuiltIn1}");
            Console.WriteLine($"BuiltIn GetValue 2: {timeToGetValueBuiltIn2}");
            Console.WriteLine($"BuiltIn GetValue 3: {timeToGetValueBuiltIn3}");

            var customSeedOverallTicks = timeToSeedCustom1 + timeToSeedCustom2 + timeToSeedCustom3;
            var builtInSeedOverallTicks = timeToSeedBuiltIn1 + timeToSeedBuiltIn2 + timeToSeedBuiltIn3;

            var customGetValueOverallTicks = timeToGetValueCustom1 + timeToGetValueCustom2 + timeToGetValueCustom3;
            var builtInGetValueOverallTicks = timeToGetValueBuiltIn1 + timeToGetValueBuiltIn2 + timeToGetValueBuiltIn3;

            Console.WriteLine($"Custom Seed overall ticks: {customSeedOverallTicks}");
            Console.WriteLine($"BuiltIn Seed overall ticks: {builtInSeedOverallTicks}");
            Console.WriteLine($"Custom GetValue overall ticks: {customGetValueOverallTicks}");
            Console.WriteLine($"BuiltIn GetValue overall ticks: {builtInGetValueOverallTicks}");

            var fastestSeed = customSeedOverallTicks > builtInSeedOverallTicks ? "BuiltIn" : "Custom";
            var fastestGetValue = customGetValueOverallTicks > builtInGetValueOverallTicks ? "BuiltIn" : "Custom";

            Console.WriteLine($"Fastest Seed: {fastestSeed}");
            Console.WriteLine($"Fastest GetValue: {fastestGetValue}");

            long SeedCustom(HashTableInt custom, int startAt)
            {
                var sw = new Stopwatch();
                sw.Start();
                for (int i = startAt; i < startAt + 99; i++)
                {
                    custom.AddOrReplace(i.ToString(), i);
                }
                sw.Stop();

                long ticks = sw.ElapsedTicks;

                Console.WriteLine($"Time to seed Custom: {ticks}");

                return ticks;
            }

            long SeedBuiltIn(Dictionary<string, int> builtIn, int startAt)
            {
                var sw = new Stopwatch();
                sw.Start();
                for (int i = startAt; i < startAt + 100; i++)
                {
                    builtIn.Add(i.ToString(), i);
                }
                sw.Stop();

                long ticks = sw.ElapsedTicks;

                Console.WriteLine($"Time to seed BuiltIn: {ticks}");

                return ticks;
            }

            long GetValueCustom(HashTableInt custom, string key)
            {
                var sw = new Stopwatch();
                sw.Start();
                custom.GetValue(key);
                sw.Stop();

                long ticks = sw.ElapsedTicks;

                Console.WriteLine($"Time to get value for Custom: {ticks}");

                return ticks;
            }

            long GetValueBuiltIn(Dictionary<string, int> builtIn, string key)
            {
                var sw = new Stopwatch();
                sw.Start();
                builtIn.TryGetValue(key, out var value);
                sw.Stop();

                long ticks = sw.ElapsedTicks;

                Console.WriteLine($"Time to get value for BuiltIn: {ticks}");

                return ticks;
            }
        }
    }
}