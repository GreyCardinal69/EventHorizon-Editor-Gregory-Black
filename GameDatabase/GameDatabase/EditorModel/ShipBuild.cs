﻿using System.Linq;
using System.Windows.Forms;
using GameDatabase.Enums;
using GameDatabase.Model;
using GameDatabase.Serializable;

namespace GameDatabase.EditorModel
{
    public class ShipBuild
    {
        public ShipBuild(SerializableShipBuild shipBuild, Database database)
        {
            ItemId = new ItemId<ShipBuild>(shipBuild.Id, shipBuild.FileName);

            ShipId = database.GetShip(shipBuild.ShipId).ItemId;
            NotAvailableInGame = shipBuild.NotAvailableInGame;
            DifficultyClass = shipBuild.DifficultyClass;
            BuildFaction = shipBuild.BuildFaction;
            Components = shipBuild.Components.Select(item => new InstalledComponent(item, database)).ToArray();
        }

        public void Save(SerializableShipBuild serializable)
        {
            serializable.ShipId = ShipId.Id;
            serializable.NotAvailableInGame = NotAvailableInGame;
            serializable.DifficultyClass = DifficultyClass;
            serializable.BuildFaction = BuildFaction;
            serializable.Components = Components.Select(item => item.Serialize()).ToArray();
        }

        public ItemId<ShipBuild> ItemId;

        public ItemId<Ship> ShipId;
        public bool NotAvailableInGame;
        public DifficultyClass DifficultyClass;
        public Faction BuildFaction;
        public InstalledComponent[] Components;
    }
}