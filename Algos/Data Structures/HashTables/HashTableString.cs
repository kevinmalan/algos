using Algos.Data_Structures.Interfaces;
using System.Collections.Generic;

namespace Algos.Data_Structures
{
    public class HashTableString : IHashTable<string>
    {
        private readonly IList<HashTableString> _hashTable = new List<HashTableString>();

        public HashTableString()
        {
        }

        public HashTableString(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }

        public void AddOrReplace(string key, string value)
        {
            foreach (var item in _hashTable)
            {
                if (item.Key == key)
                {
                    item.Value = value;
                    return;
                }
            }

            _hashTable.Add(new HashTableString(key, value));
        }

        public void AddOrIncrement(string key, string value)
        {
            foreach (var item in _hashTable)
            {
                if (item.Key == key)
                {
                    item.Value += $", {value}";
                    return;
                }
            }

            _hashTable.Add(new HashTableString(key, value));
        }

        public string GetValue(string key)
        {
            string value = default;

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