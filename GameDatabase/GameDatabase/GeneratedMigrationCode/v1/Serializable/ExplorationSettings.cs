//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using DatabaseMigration.v1.Enums;
using System;
using System.ComponentModel;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
	public class ExplorationSettingsSerializable : SerializableItem
	{
		public ExplorationSettingsSerializable()
		{
			ItemType = ItemType.ExplorationSettings;
			FileName = "ExplorationSettings.json";
		}
        [DefaultValue( "MIN(level*2,500)" )]
        public string GasCloudDPS = "MIN(level*2,500)";
        public int OutpostShip;
		public int TurretShip;
		public int InfectedPlanetFaction;
		public int HiveShipBuild;
	}
}
