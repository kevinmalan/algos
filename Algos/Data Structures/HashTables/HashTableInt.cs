using Algos.Data_Structures.Interfaces;
using System.Collections.Generic;

namespace Algos.Data_Structures
{
    public class HashTableInt : IHashTable<int>
    {
        private readonly IList<HashTableInt> _hashTable = new List<HashTableInt>();

        public HashTableInt()
        {
        }

        public HashTableInt(string key, int value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public int Value { get; set; }

        public void AddOrReplace(string key, int value)
        {
            foreach (var item in _hashTable)
            {
                if (item.Key == key)
                {
                    _hashTable.Remove(item);
                    item.Value = value;
                    _hashTable.Add(item);
                    return;
                }
            }

            _hashTable.Add(new HashTableInt(key, value));
        }

        public void AddOrIncrement(string key, int value)
        {
            foreach (var item in _hashTable)
            {
                if (item.Key == key)
                {
                    item.Value += value;
                    return;
                }
            }

            _hashTable.Add(new HashTableInt(key, value));
        }

        public int GetValue(string key)
        {
            int value = default;

            foreach (var item in _hashTable)
            {
                if (item.Key == key) return item.Value;
            }

            return value;
        }

        public void Remove(string key)
        {
            foreach (var item in _hashTable)
            {
                if (item.Key == key)
                {
                    _hashTable.Remove(item);
                    return;
                }
            }
        }

        public int GetSize()
        {
            return _hashTable.Count;
        }
    }
}