using Algos.Data_Structures;

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
    }
}