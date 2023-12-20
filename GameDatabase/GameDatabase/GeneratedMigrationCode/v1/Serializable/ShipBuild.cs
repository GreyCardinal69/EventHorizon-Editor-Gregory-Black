//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using EditorDatabase.Model;
using DatabaseMigration.v1.Enums;

namespace DatabaseMigration.v1.Serializable
{
	[Serializable]
	public class ShipBuildSerializable : SerializableItem
	{
		public ShipBuildSerializable()
		{
			ItemType = ItemType.ShipBuild;
			FileName = "ShipBuild.json";
		}
        public bool NotAvailableInGame;
        public int ShipId;
        [DefaultValue( true )]
        public bool AvailableForPlayer = true;
        [DefaultValue( true )]
        public bool AvailableForEnemy = true;
        public DifficultyClass DifficultyClass;
		public int BuildFaction;
		public InstalledComponentSerializable[] Components;
	}
}
