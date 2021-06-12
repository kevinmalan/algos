namespace Algos.Data_Structures.Interfaces
{
    public interface IHashTable<T>
    {
        void AddOrReplace(string key, T value);

        void AddOrIncrement(string key, T value);

        T GetValue(string key);

        void Remove(string key);

        int GetSize();
    }
}