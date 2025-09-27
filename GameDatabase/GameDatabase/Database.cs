using DatabaseMigration;
using EditorDatabase.Storage;

namespace EditorDatabase
{
    public partial class Database
    {
        public static Database MigrateFrom(IDataStorage storage)
        {
            Database database = new Database(null);
            DatabaseUpgrader upgrader = new DatabaseUpgrader(database._serializer, storage);
            upgrader.Upgrade(database._content);
            return database;
        }
    }
}