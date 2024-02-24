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
	public class CombatSettingsSerializable : SerializableItem
	{
		public CombatSettingsSerializable()
		{
			ItemType = ItemType.CombatSettings;
			FileName = "CombatSettings.json";
		}

		public int EnemyAI;
		public int AutopilotAI;
		public int CloneAI;
		public int DefensiveDroneAI;
		public int OffensiveDroneAI;
		public int StarbaseAI;
		public int DefaultCombatRules;
	}
}
