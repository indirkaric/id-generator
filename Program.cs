using System;

namespace IdGenerator
{
  class Program
  {
    public static string[] users = { "Q2T6HJ8", "198IOZK", "1WP4GIZ" };

    public static string[] items = { "QRT65J8", "Z9YIOZK", "14PLGIZ" };

    public const string USER_FILE = "Users.txt";

    public const string ITEM_FILE = "Items.txt";

    public static void loadData() 
    {

        var userFile = File.ReadAllLines(USER_FILE);
        var itemFile = File.ReadAllLines(ITEM_FILE);

        if (userFile.Length == 0) 
        {

            foreach (string user in users) {

                if (!userFile.Contains(user)) {

                    File.AppendAllText(USER_FILE, user + Environment.NewLine);

                }
            }

        }

        if (itemFile.Length == 0) 
        {

            foreach (string item in items) {

                if (!itemFile.Contains(item)) {

                    File.AppendAllText(ITEM_FILE, item + Environment.NewLine);

                }
            }

        }

    }

    public static bool userExists(string entityId) 
    {

        var userFile = File.ReadAllLines(USER_FILE);

        if (!userFile.Contains(entityId)) {
            return false;
        }

        return true;
    }

    public static bool itemExists(string entityId) 
    {

        var itemFile = File.ReadAllLines(ITEM_FILE);

        if (!itemFile.Contains(entityId)) {
            return false;
        }
        
        return true;
    }

    static void Main(string[] args)
    {
         if (!File.Exists(USER_FILE)) {
            var userFile = File.Create(USER_FILE);
            userFile.Close();
         }

        if (!File.Exists(ITEM_FILE)) {
            var itemFile = File.Create(ITEM_FILE);
            itemFile.Close();
         }

        loadData();

        EntityIdGenerator entityIdGenerator = new EntityIdGenerator();

        string itemEntityId = entityIdGenerator.generateEntityId(EntityIdGenerator.DEFAULT_ENTITY_ID_SIZE, itemExists);
        string userEntityId = entityIdGenerator.generateEntityId(EntityIdGenerator.DEFAULT_ENTITY_ID_SIZE, userExists);

        Console.WriteLine(itemEntityId);
        Console.WriteLine(userEntityId);
    }
  }
}
