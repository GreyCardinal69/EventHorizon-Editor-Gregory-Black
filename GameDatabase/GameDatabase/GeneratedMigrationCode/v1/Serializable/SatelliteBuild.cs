//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using DatabaseMigration.v1.Enums;
using System;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
	public class SatelliteBuildSerializable : SerializableItem
	{
		public SatelliteBuildSerializable()
		{
			ItemType = ItemType.SatelliteBuild;
			FileName = "SatelliteBuild.json";
		}

		public int SatelliteId;
		public bool NotAvailableInGame;
		public DifficultyClass DifficultyClass;
		public InstalledComponentSerializable[] Components;
	}
}
