//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;

namespace EditorDatabase.Serializable
{
	[Serializable]
	public class CombatSettingsSerializable : SerializableItem
	{
		public int EnemyAI;
		public int AutopilotAI;
		public int CloneAI;
		public int DefensiveDroneAI;
		public int OffensiveDroneAI;
        public int StarbaseAI;
        public int DefaultCombatRules;
	}
}
