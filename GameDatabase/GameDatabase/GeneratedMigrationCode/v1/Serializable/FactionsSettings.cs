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
	public class FactionsSettingsSerializable : SerializableItem
	{
		public FactionsSettingsSerializable()
		{
			ItemType = ItemType.FactionsSettings;
			FileName = "FactionsSettings.json";
		}

		[DefaultValue("MIN(1000, 300 + 5*distance)")]
		public string StarbaseInitialDefense = "MIN(1000, 300 + 5*distance)";
		[DefaultValue(50)]
		public int StarbaseMinDefense = 50;
		[DefaultValue(10)]
		public int DefenseLossPerEnemyDefeated = 10;
	}
}
