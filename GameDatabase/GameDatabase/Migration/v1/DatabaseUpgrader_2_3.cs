using System;
using System.Collections.Generic;

namespace DatabaseMigration.v1
{
    public partial class DatabaseUpgrader
    {
        partial void Migrate_2_3()
        {
            Console.WriteLine("Database migration: v1.2 -> v1.3");

            Content.GalaxySettings.StartingInventory = Content.GalaxySettings.StartingInventory;

            Dictionary<int, Serializable.ShipSerializable> ships = new Dictionary<int, Serializable.ShipSerializable>();
            foreach (Serializable.ShipSerializable item in Content.ShipList)
                ships.Add(item.Id, item);

            foreach (Serializable.ShipBuildSerializable build in Content.ShipBuildList)
            {
                build.AvailableForEnemy = !build.NotAvailableInGame && ships.TryGetValue(build.ShipId, out Serializable.ShipSerializable ship) && ship.ShipRarity != Enums.ShipRarity.Unique;
                build.AvailableForPlayer = !build.NotAvailableInGame && build.DifficultyClass == Enums.DifficultyClass.Default;
            }
        }
    }
}